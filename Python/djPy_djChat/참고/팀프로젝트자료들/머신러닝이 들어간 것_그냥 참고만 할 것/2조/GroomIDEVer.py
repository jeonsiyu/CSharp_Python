#배운 점
#1. 크롤링 통하여 프록시 우회
# 프록시 : [Errno 110] Connection timed out - proxy 설정하기(해결)
#서버와 클라이언트 사이에 중계기로써 대리로 통신을 수행하는 것, 즉 중계 기능을 하는 것'
#우회했다는 말 같음

#2. 구름꺼는 텐서가 좀 옛날거라 텐서만 업그레이드함
#pip3 install --user --upgrade tensorflow
#python3.7을 3.10으로 바꾸는 건 실패함 ㅡㅡ;

#3. 카카오 챗봇 스킬은 5초 타임아웃이 존재해서 느린 건 네이버 톡톡으로 보내야 함
#근데 이게 맞긴 하지...;

#json.loads(response_message, strict=False)
#한자같은 특수 문자떄문에 인코딩 이슈가 생겨서 안 불러와짐. 그 부분에 대한 제한을 낮춤

#response = requests.get(url, proxies=proxy, verify=False)
#프록시는 몰라도 verify나 urlopen의 timeout은 바꿔도 별 효과가 없는 듯 하다.


'''
from utils.Preprocess import Preprocess
from models.intent.IntentModel import IntentModel
from models.ner.NerModel import NerModel

from bs4 import BeautifulSoup #pip3 install --user --upgrade beautifulsoup4
from urllib import parse
import requests, json

import random
from flask import Flask, request,jsonify,abort
import urllib.request #json api 가져오기
import sys
application = Flask(__name__)
'''

import os
os.environ['TF_CPP_MIN_LOG_LEVEL'] = '2'


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

@application.route("/mytestchatbot2",methods=['POST'])
def mytestchatbot2():
    #txt = "더 공부하겠습니다. 휴먼. 무슨 말인지 모르겠어요."
    #responseBody = {
    #    "version": "2.0",
    #    "template": {
    #        "outputs": [
    #            {
    #                'simpleText' : {
    #                    'text' : txt
    #                }
    #            }
    #        ]
    #    }
    #}
    #print(txt)
    #print(responseBody)body = request.get_json()
    
    authorization_key = '5YlPTtw4SrqjmQXLieja'
    
    headers = {
        'Content-Type' : 'application/json;charset=UTF-8',
        'Authorization' : authorization_key
    }
    getReqJson = request.get_json()
    user_key = getReqJson['user']
    
    query = getReqJson['textContent']['text']
    
    print(query)
    #local = parse.quote(query)
    #print(local)
    #url = 'https://www.daegufood.go.kr/kor/api/tasty.html?mode=json&addr=%s' % local
    #print(url)
    txt = '{"status": "Michael", "last_name": "Rodgers", "department": "Marketing"}'
    proxy_url = 'https://free-proxy-list.net/'
    proxy_res = requests.get(proxy_url)
    proxy_html = proxy_res.content.decode('utf-8', 'replace')
    soup = BeautifulSoup(proxy_html, 'lxml')
    tbody = soup.select('table[class="table table-striped table-bordered"]')[0].contents[1]
    rows = tbody.find_all('tr')
    country = 'Korea'
    port = '80'
    count = 0
    #print(rows)
    #print(len(rows))
    for row in rows:
        count+=1
        print(count)
        tds = row.find_all('td')
        if True:
        #if country in tds[3].text and tds[1].text == port:
            free_proxy = tds[0].text
            proxy = {"https": free_proxy, "http": free_proxy}
            try:
                print('--1--')
                local = parse.quote('중구')
                url = 'https://www.daegufood.go.kr/kor/api/tasty.html?mode=json&addr=%s' % local
                response = requests.get(url, proxies=proxy, verify=False)
                print(f'response : {proxy_res.status_code}')
                html = response.content.decode('utf-8', 'replace')
                soup = BeautifulSoup(html, 'lxml')
                print('!html!')
                txt = json.loads(html)
                print(txt['status'])
                print('!soup!')
                #print(soup)
                print('-----2---')
                break
            except Exception as e:
                print(f'error occurred : {e}')
    
    
    #response = urllib.request.urlopen(url)
    #print(response)
    #response_message = response.read().decode('utf8')
    #print(response_message)
    #data = json.loads(response_message, strict=False)
    #print(data)
    
    print(txt)
    json_arr = txt['data']
    
    data = {
        'event':"send",
        'user':user_key,
        'textContent':{
            "text":json_arr
        }
    }
    
    message = json.dumps(data)
    response = requests.post('https://gw.talk.naver.com/chatbot/v1/event',
                            headers=headers,
                            data=message)
    print(response)
    return response

@application.route("/mytestchatbot_work2",methods=['POST'])
def mytestchatbot_work2():
    print("안녕")
    body = request.get_json()
    
    authorization_key = '5YlPTtw4SrqjmQXLieja'
    
    headers = {
        'Content-Type' : 'application/json;charset=UTF-8',
        'Authorization' : authorization_key
    }
    getReqJson = request.get_json()
    user_key = getReqJson['user']
    
    query = getReqJson['textContent']['text']
    
    data = {
        'event':"send",
        'user':user_key,
        'textContent':{
            "text":query
        }
    }
    print(data)
    #query = body['userRequest']['utterance']
    print(query)
    txt = ""
    p = Preprocess(word2index_dic='./train_tools/dict/chatbot_dict.bin',
               userdic='./utils/user_dic.tsv')

    intent = IntentModel(model_name='./models/intent/intent_model.h5', preprocess=p)
    ner = NerModel(model_name='./models/ner/ner_model.h5', preprocess=p)
    predict = intent.predict_class(query)
    predict_label = intent.labels[predict]
    predicts = ner.predict(query)
    tags = ner.predict_tags(query)
    print(predict_label)
    if predict_label=="인사":
        txt = txt + "반갑습니다."
        print(txt)
    elif predict_label=="욕설":
        txt = txt + "미쳤습니까 휴먼?"
        print(txt)
    elif predict_label=="주문" or predict_label=="예약":
        print("의도:",predict_label)
        food_name = ""
        for item in predicts:
            if item[1] == 'B_FOOD': #음식에 해당하는 내용이 있는 경우
                food_name=item[0]
                break
        
        local_list=["동구", "수성구","북구","서구","중구","남구","달서구","달성군"]
        restaurant_list = []
        for item in local_list:
                #print(item)
            #local = parse.quote(item)
            #url = 'https://www.daegufood.go.kr/kor/api/tasty.html?mode=json&addr=%s' % local
            proxy_url = 'https://free-proxy-list.net/'
            proxy_res = requests.get(proxy_url)
            proxy_html = proxy_res.content.decode('utf-8', 'replace')
            soup = BeautifulSoup(proxy_html, 'lxml')
            tbody = soup.select('table[class="table table-striped table-bordered"]')[0].contents[1]
            rows = tbody.find_all('tr')
            country = 'Korea'
            port = '80'
            count = 0
            json_arr=[]
            for row in rows:
                count+=1
                print(count)
                tds = row.find_all('td')
                #if True:
                #if country in tds[3].text and tds[1].text == port:
                if country in tds[3].text:
                    free_proxy = tds[0].text
                    proxy = {"https": free_proxy, "http": free_proxy}
                    try:
                        print('--1--')
                        local = parse.quote(item)
                        url = 'https://www.daegufood.go.kr/kor/api/tasty.html?mode=json&addr=%s' % local
                        response = requests.get(url, proxies=proxy, verify=False)
                        print(f'response : {proxy_res.status_code}')
                        html = response.content.decode('utf-8', 'replace')
                        soup = BeautifulSoup(html, 'lxml')
                        print('!html!')
                        json_arr = json.loads(html, strict=False)['data']
                        #print(json_arr['status'])
                        print('!soup!')
                        #print(soup)
                        print('-----2---')
                        break
                    except Exception as e:
                        print(f'error occurred : {e}')
            
            
            #response = urllib.request.urlopen(url)
            #response_message = response.read().decode('utf8')
            #data = json.loads(response_message, strict=False)
            #json_arr = data['data']
            restaurant_list = restaurant_list + json_arr
        myrestaurant_list = []
        if food_name != "":
            myrestaurant_list = list(filter(lambda n: food_name in n['MNU'], restaurant_list))

        if len(myrestaurant_list)==0:
            txt = "그건 없네요. 아무거나 드셔 보세요.\n"
            myrestaurant_list = restaurant_list
            #print(restaurant_list)
            #print(local)
            #print(restaurant_list)
        myrestaurant = random.choice(myrestaurant_list)
            #print(len(restaurant_list)) #1019 , 35


        txt = txt + "이 식당에 가보시는 거 어떠세요?\n"
        txt = txt + "식당 이름 : " +myrestaurant['BZ_NM'].replace('<br','').replace(' />','') + "\n"
        txt = txt + "식당 주소 : " +myrestaurant['GNG_CS'].replace('<br','').replace(' />','\n')
        #txt = txt +myrestaurant['FD_CS'].replace('<br','').replace(' />','\n')
        #txt = txt +myrestaurant['TLNO'].replace('<br','').replace(' />','\n')
        #txt = txt +myrestaurant['MBZ_HR'].replace('<br','').replace(' />','\n')
        #txt = txt +myrestaurant['SEAT_CNT'].replace('<br','').replace(' />','\n')
        #txt = txt +myrestaurant['MNU'].replace('<br','').replace(' />','\n')
        #mymenus = str((myrestaurant['MNU']))
        #mymenus = mymenus.replace('<br','')
        #mymenus = mymenus.replace(' />','\n')
        #mymenus = myrestaurant['MNU'].replace('<br />','\n')
        #print(mymenus)
        #txt = txt + myrestaurant['SMPL_DESC'].replace('<br','').replace(' />','\n')
        #txt = txt + myrestaurant['SBW'].replace('<br','').replace(' />','\n')
        #txt = txt + myrestaurant['BUS'].replace('<br','').replace(' />','\n')
        #txt = txt + myrestaurant['BKN_YN'].replace('<br','').replace(' />','\n')
    else:
        txt = txt + "더 공부하겠습니다. 휴먼. 무슨 말인지 모르겠어요."
        
    #responseBody = {
    #    "version": "2.0",
    #    "template": {
    #        "outputs": [
    #            {
    #                'simpleText' : {
    #                    'text' : txt
    #                }
    #            }
    #        ]
    #    }
    #}
    print(txt)
    #print(responseBody)
    #print(jsonify(responseBody))
    data = {
        'event':"send",
        'user':user_key,
        'textContent':{
            "text":txt
        }
    }
    print(data)
    message = json.dumps(data)
    print(message)
    response = requests.post('https://gw.talk.naver.com/chatbot/v1/event',
                            headers=headers,
                            data=message)
    print(response)
    return response

@application.route("/mytestchatbot_kakaotest",methods=['POST'])
def mytestchatbot_kakaotest():

    responseBody = {
            "version": "2.0",
            "template": {
                "outputs": [
                    {
                        'simpleText' : {
                            'text' : '감정 : ' + 'emo'
                        }
                    }
                ]
            }
        }
    return responseBody
@application.route("/mytestchatbot",methods=['POST'])
def mytestchatbot():
    #1 데이터 읽어오기
    print("시작")
    txt = ""
    train_file = "movie_data.csv"
    data = pd.read_csv(train_file,delimiter=',')
    features = data['query'].tolist()
    #print("메시지를 입력해보세요! 영화추천? 로또? 어떤 게 나올지 두근 두근~")
    #q = input()
    #body = request.get_json()
    #q = body['userRequest']['utterance']
    body = request.get_json()
    
    authorization_key = '5YlPTtw4SrqjmQXLieja'
    
    headers = {
        'Content-Type' : 'application/json;charset=UTF-8',
        'Authorization' : authorization_key
    }
    getReqJson = request.get_json()
    user_key = getReqJson['user']
    
    q = getReqJson['textContent']['text']
    
    data = {
        'event':"send",
        'user':user_key,
        'textContent':{
            "text":q
        }
    }
    
    
    print(q)
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
    except Exception as e:
        print(f'error occurred : {e}')
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
        txt = "영화에 관련된 얘기는 아닌 것 같네요. 혹시 로또 사보실래요?\n명당 추천들어갑니다~\n"
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
        txt = "영화에 관련된 이야기를 하셨으니 영화를 추천해볼게요."
        txt = txt + "오늘(%s)의 박스오피스는!?" % "월"
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
            
            
    #responseBody = {
    #        "version": "2.0",
    #        "template": {
    #            "outputs": [
    #                {
    #                    'simpleText' : {
    #                        'text' : txt
    #                    }
    #                }
    #            ]
    #        }
    #    }
    #print(txt)
    #print(responseBody)
    data = {
        'event':"send",
        'user':user_key,
        'textContent':{
            "text":txt
        }
    }
    #print(data)
    message = json.dumps(data)
    #print(message)
    response = requests.post('https://gw.talk.naver.com/chatbot/v1/event',
                            headers=headers,
                            data=message)
    data = {
        'event':"send",
        'user':user_key,
        'textContent':{
            "text":'또 하실 말씀있으신가요?'
        }
    }
    #print(data)
    message = json.dumps(data)
    response = requests.post('https://gw.talk.naver.com/chatbot/v1/event',
                            headers=headers,
                            data=message)
    #return responseBody

if __name__ == "__main__":
    application.run(host='0.0.0.0', port=8080)
    #application.run(host='0.0.0.0', port=5008)
