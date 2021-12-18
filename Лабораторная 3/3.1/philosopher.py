import threading
import random
import time

#Наследование класса потоков
class Philosopher(threading.Thread):
    running = True 

    def __init__(self, index, forkOnLeft, forkOnRight):
        threading.Thread.__init__(self)
        self.index = index
        self.forkOnLeft = forkOnLeft
        self.forkOnRight = forkOnRight

    def run(self):
        while(self.running):
            time.sleep(30)
            print ('Философер %s голоден' % self.index)
            self.dine()

    def dine(self):
        fork1, fork2 = self.forkOnLeft, self.forkOnRight
        while self.running:
            fork1.acquire() # Ждать левую вилку
            locked = fork2.acquire(False) 
            if locked: break #Если правой вилки нет, убрать левую вилку
            fork1.release()
            print ('Философер %s меняет вилки.' % self.index)
            fork1, fork2 = fork2, fork1
        else:
            return
        self.dining()
        #После еды убрать вилки
        fork2.release()
        fork1.release()
 
    def dining(self):			
        print ('Философ %s ест '% self.index)
        time.sleep(30)
        print ('Философ %s закончил и идет думать' % self.index)


forks = [threading.Semaphore() for n in range(5)] 

philosophers= [Philosopher(i, forks[i%5], forks[(i+1)%5])
    for i in range(5)]

Philosopher.running = True
for p in philosophers: p.start()
time.sleep(100)
Philosopher.running = False
print ("Конец обеда")
 

