from utils.Preprocess import Preprocess
from models.intent.IntentModel import IntentModel
from models.ner.NerModel import NerModel
import urllib.request
from urllib import parse
import json
import random
import speech_recognition as sr


p = Preprocess(word2index_dic='./train_tools/dict/chatbot_dict.bin',
               userdic='./utils/user_dic.tsv')

intent = IntentModel(model_name='./models/intent/intent_model.h5', preprocess=p)
ner = NerModel(model_name='./models/ner/ner_model.h5', preprocess=p)
while True:
    #self.labels = {0: "인사", 1: "욕설", 2: "요리", 3: "음식", 4: "기타"}

    # 사용자의 말을 입력받는다.
    r = sr.Recognizer()
    query = ""
    with sr.Microphone() as source:
        print("혹시 배고프신지요. 먹고 싶은 음식과 함께 하고 싶은 말을 해보세요!")
        speech = r.listen(source)
        query = "안녕하세요"
    try:
        query = r.recognize_google(speech, language="ko-KR")
        print(str(query))
    except:
        print("무슨 말인지 모르겠어요.")

    predict = intent.predict_class(query)
    predict_label = intent.labels[predict]
    predicts = ner.predict(query)
    #print(predicts) # [('오늘', 'B_DT'), ('탕수육', 'B_FOOD'), ('주문', 'O'), ('가능', 'O')]

    if predict_label=="인사":
        print("안녕하세요. 반갑습니다. 어떻게 도와드릴까요?")
    elif predict_label=="욕설":
        print("나쁜 말은 안 됩니다!")
    elif predict_label=="요리" or predict_label=="음식":
        food_name = ""
        for item in predicts:
            print(item) # ('오늘', 'B_DT') ('탕수육', 'B_FOOD')
            if item[1] == 'B_FOOD': #음식에 해당하는 내용이 있는 경우
                food_name=item[0] #'탕수육' 등
                break
        #print('food_name?')
        #print(food_name)
        key = '309cd91920164798a42f'
        food_name = urllib.parse.quote(food_name)
        #print(food_name)
        url = f'https://openapi.foodsafetykorea.go.kr/api/{key}/COOKRCP01/json/1/1000/RCP_NM={food_name}'
        if food_name == "": #의도는 파악했으나 B_FOOD를 못 찾은 경우
            print("그 음식 만드는 법은 모르겠어요. 이건 어떠세요?")
            url = f'https://openapi.foodsafetykorea.go.kr/api/{key}/COOKRCP01/json/1/1000'
        #print(url)
        response = urllib.request.urlopen(url)
        response_message = response.read().decode('utf8')

        #print(response_message)
        data = json.loads(response_message)
        #count = int(data['COOKRCP01']['total_count'])
        #의도파악하고 음식을 인식은 했는 데 해당 음식이 없는 경우
        try:
            data = data['COOKRCP01']['row']
        except:
            print("죄송해요. 그 음식 만드는 법은 모르겠어요. 이건 어떠세요?")
            url = f'https://openapi.foodsafetykorea.go.kr/api/{key}/COOKRCP01/json/1/1000'
            response = urllib.request.urlopen(url)
            response_message = response.read().decode('utf8')
            data = json.loads(response_message)
            data = data['COOKRCP01']['row']

        #print(response_message)
        #print(data)
        #print(len(data))
        #print(count)
        mydata = random.choice(data) #무작위로 하나 뽑아준다.
        #print(f"재료:{data[0]['RCP_PARTS_DTLS']}")
        print(f"음식이름:{mydata['RCP_NM']}")
        print(f"재료:{mydata['RCP_PARTS_DTLS']}")
        print(f"조리방법:{mydata['RCP_WAY2']}")
        print(f"요리종류:{mydata['RCP_PAT2']}")
        #manual = ""
        print("요리 방법")
        for item in range(1,21):
            item = str(item)
            item = item.zfill(2)
            if mydata['MANUAL'+item]=="":
                break
            print(f"{mydata['MANUAL'+item]}".replace("\n",""))
            #manual = "\n"+manual + mydata['MANUAL'+item]
        #print(f"!!요리방법\n{manual}")
    else:
        print("더 공부해서 잘 대답하는 챗봇이 될게요!")