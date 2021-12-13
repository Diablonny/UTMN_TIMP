import random
import string
from time import process_time
from multiprocessing.dummy import Pool

def writing(n):
    with open(f'{n}.txt', 'w') as f:
        for i in range(100000):
            f.write(f"{n} - {''.join(random.choices(string.ascii_letters, k = m))}\n")
    print(f"файл {n} записан")

def consolidating(n, final = 'consolidated.txt'):
    with open(f"{n}.txt", 'r') as fr:
        print(f"Берем данные из {n}")
        with open(final, 'a') as fc:
            fc.write(''.join(fr.readlines()))

n = int(input("Введите количество файлов N: "))
m = int(input("Введите длину строк M: "))

start_time = process_time()
with Pool(n) as p:
    p.map(writing, [i+10 for i in range(n)])
print(f'Потоковая запись. Длина {m} символа в {n} файлов. Потрачено {process_time()-start_time} секунд.')

start_time = process_time()
with Pool(n) as p:
    p.map(consolidating, [i+10 for i in range(n)])
print(f'Потоковая склейка. Длина {m} символа из {n} файлов. Потрачено {process_time()-start_time} секунд.')

