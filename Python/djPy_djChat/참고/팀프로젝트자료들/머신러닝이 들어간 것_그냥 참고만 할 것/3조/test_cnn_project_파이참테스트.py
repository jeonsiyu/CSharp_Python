
import os
os.environ['TF_CPP_MIN_LOG_LEVEL'] = '2'


import tensorflow as tf
import pandas as pd
from tensorflow.keras.models import Model, load_model
from tensorflow.keras import preprocessing

import datetime

import urllib.request

import json

import random

print(tf.__version__)
#1 데이터 읽어오기
train_file = "movie_data.csv"
data = pd.read_csv(train_file,delimiter=',')
features = data['query'].tolist()
print("메시지를 입력해보세요! 영화추천? 로또? 어떤 게 나올지 두근 두근~")
q = input()
features.append(q)

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

print(corpus[len(features)-1]) # ['다', '괜찮은', '줄', '알았는데']
print(sequences[len(features)-1]) #[28, 242, 85, 118]
print(padded_seqs[len(features)-1]) #[ 28 242  85 118   0   0   0   0   0   0   0   0   0   0   0]

emotions = {0:"인사", 1:"추천",2:"예매",3:"평가", 4:"기타"}
emo = emotions[4]
try:
    predict = model.predict(padded_seqs[picks])
    predict_class = tf.math.argmax(predict, axis=1)
    emo = emotions[predict_class.numpy()[0]]
except:
    pass
'''
인사(0): 텍스트가 인사인 경우 => 영화평이 좋다는 말은 아닌 것 같네요. 로또 하나 사시겠어요? 여기서 사보시는 거 어때요?
추천(1): 텍스트가 추천 관련 내용인 경우 => 이번주 영화 추천 리스트 
예매(2): 텍스트가 예매 관련 내용인 경우 => 이번주 영화 추천 리스트 
평가(3): 텍스트가 긍정적인 평가 관련 내용인 경우 => 이번주 영화 추천 리스트 
기타(4): 어떤 의도에도 포함되지 않는 경우 (욕설 포함) => 영화평이 좋다는 말은 아닌 것 같네요. 로또 하나 사시겠어요? 여기서 사보시는 거 어때요?
'''


#print('감정 예측 점수 : ', predict)
#print('감정 예측 클래스 : ' , predict_class.numpy())
print('감정 : ' , emo)

#0 안녕하세요, 반갑습니다.
#1 영화 추천 해요, 영화 추천해줘, 볼만한거 원해요
#2 영화 예매, 월요일 영화 예매
#3 스토리가 최악
#4 사과해야 하나?

if emo=="인사" or emo=="기타":
    print("영화에 관련된 얘기는 아닌 것 같네요. 혹시 로또 사보실래요? 명당 추천들어갑니다~")
    url = "https://api.odcloud.kr/api/15059963/v1/uddi:5c8a1e17-cc23-438a-a458-c72197dfce74?page=1&perPage=1000&serviceKey=I35xhBVrKuRe7RbiQpN9NOkt%2B6JQT5Fd0fgCNDuB0dURcjnYRTmTeyrFaNHFDHVY%2FQ4etMclK24pY%2FdEMx2fGQ%3D%3D"
    response = urllib.request.urlopen(url)
    response_message = response.read().decode('utf8')
    data = json.loads(response_message, strict=False)
    json_arr = data['data']
    mylottoplace = random.choice(json_arr)
    print(mylottoplace['상호'])
    count = '1등 자동 당첨 건수 : %s' % mylottoplace['1등 자동 당첨 건수']
    print(count)
    print(mylottoplace['지역'])
    #"1등 자동 당첨 건수":"5","상호":"일등복권편의점","순번":"1","지역":"대구 달서구"
else:
    print("영화에 관련된 이야기를 하셨으니 영화를 추천해볼게요.")
    print("오늘(%s)의 박스오피스는!?" % "월")
    now = datetime.datetime.now()
    now_before_1 = now - datetime.timedelta(days=1)
    boxday = "%s%s%s" % (now_before_1.strftime("%Y"),now_before_1.strftime("%m"),now_before_1.strftime("%d"))
    url = "http://www.kobis.or.kr/kobisopenapi/webservice/rest/boxoffice/searchDailyBoxOfficeList.json?key=43acf2413769000d8f1218245a94a6ba&targetDt=%s" % boxday
    response = urllib.request.urlopen(url)
    response_message = response.read().decode('utf8')
    data = json.loads(response_message, strict=False)
    #json_arr = data['data']
    boxlist = data['boxOfficeResult']['dailyBoxOfficeList']
    for item in boxlist:
        print(item['rank'])
        print(item['movieNm'])
        print(item['openDt'])