def calcArea(width, height):
    return width*height

class Student:
    def __init__(self,name,age):
        self.name = name
        self.age = age
    def __del__(self):
        print('소멸됩니다')
    def introduce(self):
        print('이름 {}, 나이 {}'.format(self.name,self.age))

print(calcArea(10,5))
print(calcArea(height=7,width=8))
s = Student('이동준',35)
s2 = Student(age=25,name='이유나')
s.introduce()
s2.introduce()