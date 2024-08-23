# 처음 실행때는 잘 안 됐으나 두 번째 하니까 빨리 됨
# GPU 말고 다른 거에서도 이거 지우니까 더 빨리 됨. 대신 카톡 챗봇 타임아웃엔 걸림....
#import os
#os.environ['TF_CPP_MIN_LOG_LEVEL'] = '2'



import tensorflow as tf
import pandas as pd
from tensorflow.keras.models import Model, load_model
from tensorflow.keras import preprocessing

import datetime

import requests,json

import random


from flask import Flask, request, jsonify,abort
import urllib.request #json api 가져오기
import sys
application = Flask(__name__)


@application.route("/")
def hello():
    return "Hello goorm!"

@application.route("/mychatbot",methods=['POST'])
def mychatbot():
    #1 데이터 읽어오기
    #print("시작")
    txt = ""
    train_file = "movie_data.csv"
    data = pd.read_csv(train_file,delimiter=',')
    features = data['query'].tolist()
    #print("메시지를 입력해보세요! 영화추천? 로또? 어떤 게 나올지 두근 두근~")
    #q = input()
    body = request.get_json()
    q = body['userRequest']['utterance']
    #body = request.get_json()
    
    #authorization_key = '5YlPTtw4SrqjmQXLieja'
    
    #headers = {
    #    'Content-Type' : 'application/json;charset=UTF-8',
    #    'Authorization' : authorization_key
    #}
    #getReqJson = request.get_json()
    #user_key = getReqJson['user']
    
    #q = getReqJson['textContent']['text']
    
    #data = {
    #    'event':"send",
    #    'user':user_key,
    #    'textContent':{
    #        "text":q
    #    }
    #}
    
    
    #print(q)
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

    #print(corpus[len(features)-1]) # ['다', '괜찮은', '줄', '알았는데']
    #print(sequences[len(features)-1]) #[28, 242, 85, 118]
    #print(padded_seqs[len(features)-1]) #[ 28 242  85 118   0   0   0   0   0   0   0   0   0   0   0]

    emotions = {0:"인사", 1:"추천",2:"예매",3:"평가", 4:"기타"}
    emo = emotions[4]
    try:
        predict = model.predict(padded_seqs[picks])
        predict_class = tf.math.argmax(predict, axis=1)
        emo = emotions[predict_class.numpy()[0]]
    except Exception as e:
        pass#print(f'error occurred : {e}')


    #print('감정 : ' , emo)


    if emo=="인사" or emo=="기타":
        txt = "영화에 관련된 얘기는 아닌 것 같네요.\n혹시 로또 사보실래요?\n명당 추천들어갑니다~\n"
        url = "https://api.odcloud.kr/api/15059963/v1/uddi:5c8a1e17-cc23-438a-a458-c72197dfce74?page=1&perPage=1000&serviceKey=I35xhBVrKuRe7RbiQpN9NOkt%2B6JQT5Fd0fgCNDuB0dURcjnYRTmTeyrFaNHFDHVY%2FQ4etMclK24pY%2FdEMx2fGQ%3D%3D"
        response = urllib.request.urlopen(url)
        response_message = response.read().decode('utf8')
        data = json.loads(response_message, strict=False)
        json_arr = data['data']
        mylottoplace = random.choice(json_arr)
        txt = txt + "가게 이름 : " + mylottoplace['상호'] + "\n"
        #count = '1등 자동 당첨 건수 : %s\n' % mylottoplace['1등 자동 당첨 건수']
        #txt = txt + count + "\n"
        txt = txt + "가게 지역 : "+ mylottoplace['지역']
        #"1등 자동 당첨 건수":"5","상호":"일등복권편의점","순번":"1","지역":"대구 달서구"
    else:
        txt = "영화에 관련된 이야기를 하셨으니 영화를 추천해볼게요.\n"
        txt = txt + "어제의 박스오피스는!?\n"
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
            txt = txt + item['rank'] + "\n"
            txt = txt +item['movieNm']+ "\n"
            txt = txt +item['openDt']+ "\n"
            
            
    responseBody = {
            "version": "2.0",
            "template": {
                "outputs": [
                    {
                        'simpleText' : {
                            'text' : txt
                        }
                    }
                ]
            }
        }
    #print(txt)
    #print(responseBody)
    #data = {
    #    'event':"send",
    #    'user':user_key,
    #    'textContent':{
    #        "text":txt
    #    }
    #}
    #print(data)
    #message = json.dumps(data)
    #print(message)
    #response = requests.post('https://gw.talk.naver.com/chatbot/v1/event',
    #                        headers=headers,
    #                        data=message)
    #data = {
    #    'event':"send",
    #    'user':user_key,
    #    'textContent':{
    #        "text":'또 하실 말씀있으신가요?'
    #    }
    #}
    #print(data)
    #message = json.dumps(data)
    #response = requests.post('https://gw.talk.naver.com/chatbot/v1/event',
    #                        headers=headers,
    #                        data=message)
    return responseBody

if __name__ == "__main__":
    application.run(host='0.0.0.0', port=8080)
    #application.run(host='0.0.0.0', port=5008)
