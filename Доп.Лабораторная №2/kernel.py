from ctypes import *
from ctypes import wintypes as w
import random
import string
import time

class Kernel:

    #GENERIC_READ = 0x10000000
    #GENERIC_WRITE = 0x20000000
    #FILE_SHARE_READ = 0x00000001
    #FILE_SHARE_WRITE = 0x00000002
    #OPEN_ALWAYS = 4
    #FILE_ATTRIBUTE_NORMAL = 0x80
    
    @staticmethod
    def WriteFile(file_name, _string):
        file_handler = windll.Kernel32.CreateFileW(file_name, 
                                                  0x10000000 | 0x20000000, 
                                                  0x00000001 | 0x00000002, 
                                                  None, 4, 
                                                  0x80, None)
        pointer_to_written_data=c_int(0)
        windll.Kernel32.WriteFile(file_handler, _string, len(_string)*2, byref(pointer_to_written_data), None)
        windll.Kernel32.CloseHandle(file_handler)
        return    
    
    @staticmethod
    def ReadFile(file_name):
        file_handler = windll.Kernel32.CreateFileW(file_name, 
                                                   0x10000000 | 0x20000000, 
                                                   0x00000001 | 0x00000002, 
                                                   None, 4, 
                                                   0x80, None)
        data = create_string_buffer(4096)
        read = w.DWORD()
        windll.kernel32.ReadFile(file_handler, byref(data), 1024, byref(read), None)
        windll.Kernel32.CloseHandle(file_handler)
        return 

def WriteFilePython(file, text):
    with open(file, 'w') as file:
        file.write(text)

def ReadFilePython(file):
    with open(file, 'r') as file:
        data = file.read()

text = ''
for i in range(10000):
    text += ''.join(random.choice(string.ascii_letters) for i in range(10)) + '\n'

start = time.perf_counter()
Kernel.WriteFile('kernel.txt', text)
stop = time.perf_counter()
print(f'Запись строк через kernel32 - {(stop - start):0.4f} секунд.')

start = time.perf_counter()
Kernel.ReadFile('kernel.txt')
stop = time.perf_counter()
print(f'Чтение файла через kernel32 - {(stop - start):0.4f} секунд.\n')

start = time.perf_counter()
WriteFilePython('py.txt', text)
stop = time.perf_counter()
print(f'Запись строк стандартно - {(stop - start):0.4f} секунд.')

start = time.perf_counter()
ReadFilePython('py.txt')
stop = time.perf_counter()
print(f'Чтение файла стандартно - {(stop - start):0.4f} секунд.\n')
