import random
import string
import hashlib
import time
import random

global txt
txt = 'check.txt'

class Node():
    def __init__(self, value = None, offset = None, left = None, right = None):
        self._value = value 
        self._offset = offset 
        self._left = left 
        self._right = right 
    
    def __str__(self):
      return str(self._value)

class Tree():
    def __init__(self):
        self._root = None

    @property
    def get_root(self):
        return self._root

    def add(self, value, offset):
      if self._root is None:
          self._root = Node(value, offset)
      else:
          self.__add(value, offset, self._root)
    
    def __add(self, value, offset, node):
      if value < node._value:
          if node._left is not None:
              self.__add(value, offset, node._left)
          else:
              node._left = Node(value, offset)
      else:
          if node._right is not None:
              self.__add(value, offset, node._right)
          else:
              node._right = Node(value, offset)

    def search(self, node, value):
        if node._value is not None:
            if node._value == value:
                return node._offset
            else:
                if value > node._value:
                    return self.search(node._right, value)
                return self.search(node._left, value)
        else:
            return "Дерево пустое"

def random_string(length = 12):
    letters = string.ascii_letters+string.punctuation
    rand_string = ''.join(random.choice(letters) for i in range(length))
    return rand_string

def generate_hash(str): #функция генерирования хэша строки
    hash = (int(hashlib.md5(str.encode('utf-8')).hexdigest(), 16)%10**8)
    return hash

#поиск по дереву
def t_search_timings(t, hashes): 
    for hash in hashes:
        t.search(t.get_root, hash)

#поиск по файлу
def f_search_timings(hashes):
    f = open(txt).readlines()
    for i in hashes:
        for line in f:
            if str(i) in line:
                break

t = Tree()
hashes = [] 
search_hashes = [] 

with open(txt, 'w') as f:

    for i in range(10000):
        tmp_string = random_string()
        tmp_hash = generate_hash(tmp_string) #присваем хеш строке
        hashes.append(tmp_hash)

        t.add(tmp_hash, i)
        f.write(tmp_string + " - " + str(tmp_hash) + '\n') #сохраняем строку с хешем
    for i in range(10000):
            search_hashes.append(random.choice(hashes))

    print(f"{len(search_hashes)} хешей из файла")
    start_time = time.process_time()
    f_search_timings(search_hashes) 
    print(f"Потрачено {time.process_time()-start_time}\n")

    print(f"{len(search_hashes)} хешей из дерева")
    start_time = time.process_time()
    t_search_timings(t, search_hashes)
    print(f"Потрачено {time.process_time()-start_time}")

