import speech_recognition as sr

import urllib.request
import json

import random

import os
os.environ['TF_CPP_MIN_LOG_LEVEL'] = '2'
import tensorflow as tf
import pandas as pd
from tensorflow.keras.models import Model, load_model
from tensorflow.keras import preprocessing

# 사용자의 말을 입력받는다.
r = sr.Recognizer()
with sr.Microphone() as source:
    print("하고 싶은 말을 해보세요.")
    speech = r.listen(source)
    audio = "안녕하세요"
try:
    audio = r.recognize_google(speech, language="ko-KR")
    print(str(audio))
except :
    print("무슨 말인지 모르겠어요.")


#1 데이터 읽어오기
train_file = "chatbot_data.csv"
data = pd.read_csv(train_file,delimiter=',')
features = data['Q'].tolist()

features.append(audio)

#2 단어 인덱스 시퀀스 벡터
corpus = [preprocessing.text.text_to_word_sequence(text) for text in features]

tokenizer = preprocessing.text.Tokenizer()
tokenizer.fit_on_texts(corpus) #fit_on_texts() 메서드는 문자 데이터를 입력받아서 리스트의 형태로 변환합니다.
sequences = tokenizer.texts_to_sequences(corpus)

MAX_SEQ_LEN  = 15
padded_seqs = preprocessing.sequence.pad_sequences(sequences, maxlen=MAX_SEQ_LEN, padding='post')

#4 감정 분류 CNN 모델 불러 오기
model = load_model('cnn_model.h5')


picks = [len(features)-1]
#picks = [11823]

#print(corpus[len(features)-1]) # ['다', '괜찮은', '줄', '알았는데']
#print(sequences[len(features)-1]) #[28, 242, 85, 118]
#print(padded_seqs[len(features)-1]) #[ 28 242  85 118   0   0   0   0   0   0   0   0   0   0   0]

try:
    predict = model.predict(padded_seqs[picks])
    predict_class = tf.math.argmax(predict, axis=1)
    emo = predict_class.numpy()[0]
except:
    emo = 0

emotions = {0:"보통", 1:"부정", 2:"긍정"}

#print('감정 예측 점수 : ', predict)
#print('감정 예측 클래스 : ' , predict_class.numpy())
print('감정 : ' , emotions[emo])

if emotions[emo] == "부정":
    print("사는 지역이 어디신가요? ")
    location = input()
    try:

        url = 'https://api.odcloud.kr/api/3049990/v1/uddi:14a6ea21-af95-4440-bb05-81698f7a1987?page=1&perPage=3000&serviceKey=I35xhBVrKuRe7RbiQpN9NOkt%2B6JQT5Fd0fgCNDuB0dURcjnYRTmTeyrFaNHFDHVY%2FQ4etMclK24pY%2FdEMx2fGQ%3D%3D'

        response = urllib.request.urlopen(url)
        response_message = response.read().decode('utf8')

        #print(response_message)
        data = json.loads(response_message)

        json_arr = data['data']
        hospitals = []
        for item in json_arr:
            if location in item['주소']:
                hospitals.append(item)
        print("여기 어떠세요? 도움을 받아보세요.")
        helper = random.choice(hospitals)
        print(helper['기관명'])
        print(helper['주소'])
    except:
        print("어딘지 모르겠어요. 도움을 받으셔야 할 것 같아요.")
        print("정신건강복지센터 및 정신건강상담전화 운영")
        print("정신건강 위기상담전화(1577-0199)")
        print("국번 없이 129(보건복지콜센터)")
elif emotions[emo] == "긍정":
    print("이 감정 그대로 가져 가셨으면 좋겠어요.")
else:
    print("오늘은 보통이신 것 같아요.")

#너무우울해 1

#사랑 2
#짝사랑 1
#귀찮게 굴지 마세요 except
#안녕하세요 0
#봄 타나 봐 2
#기분이 좋아요 2
#슬퍼 1
#비참하다 1