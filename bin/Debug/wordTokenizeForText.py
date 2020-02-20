
import nltk
from nltk.tokenize import sent_tokenize, word_tokenize
import string


class calculator:
    def add(self, a,b):
        res=[]
        for i in sent_tokenize(a,b):
           for c in string.punctuation:
               i= i.replace(c,"")
           res.append(word_tokenize(i,b))
        return res
