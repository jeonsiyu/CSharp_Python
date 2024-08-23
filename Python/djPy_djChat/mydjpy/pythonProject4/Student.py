class Student:
    def __init__(self,name,age):
        self.name = name
        self.age = age
    def __del__(self):
        print('소멸됩니다')
    def introduce(self):
        print('이름 {}, 나이 {}'.format(self.name,self.age))