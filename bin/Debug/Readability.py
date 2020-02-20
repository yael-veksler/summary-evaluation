import nltk
nltk.download('averaged_perceptron_tagger')
from nltk.tokenize import (
    punkt,
    word_tokenize,
    sent_tokenize,
    TweetTokenizer,
    StanfordSegmenter,
    TreebankWordTokenizer,
    SyllableTokenizer,
)
from nltk import pos_tag
import string
import sys
data= sys.argv[1]

#data=" The Dog Fanciers Club organized a lunch at Sardi's on Wednesday for two of their champions, the city's top police dog and the nation's top show dog. "

sentences = sent_tokenize(data)
sentence_count=len(sentences)

word_count=0
properNounsTag=['NNP']
nounsTag=['NN', 'NNS']
pronounsTag=['PRP', 'PRP$']

properNouns_count=0
nouns_count=0
pronouns_count=0

complexWords_count=0
characters=0
syllables_count=0

SSP = SyllableTokenizer()

for sentence in sentences:
     clean_sentence=sentence.translate(string.maketrans("",""), string.punctuation)
     words = word_tokenize(clean_sentence)
     word_count+=len(words)
     for word in words:
         characters+=len(word)
     for word,tag in pos_tag(words):
         if tag in properNounsTag:
              properNouns_count+=1
         if tag in nounsTag:
              nouns_count+=1
         if tag in pronounsTag:
              pronouns_count+=1
     for word in words:
         length=len(SSP.tokenize(word))
         syllables_count +=length
         if length>=3:
              complexWords_count+=1

PNR=properNouns_count/(word_count+0.0)
NR=nouns_count/(word_count+0.0)
PR=pronouns_count/(word_count+0.0)
Fog=0.4*((word_count/(sentence_count+0.0))+100*(complexWords_count/(word_count+0.0)))
AWL=characters/(word_count+0.0)
Flesch_Reading_Ease=206.835-1.015*(word_count/(sentence_count+0.0))-84.6*(syllables_count/(word_count+0.0))
Flesch_Kincaid_Grade_Level= 0.39*(word_count/(sentence_count+0.0))+11.8*(syllables_count/(word_count+0.0))-15.59

print(PNR)
print(NR)
print(PR)
print(Fog)
print(AWL)
print(Flesch_Reading_Ease)
print(Flesch_Kincaid_Grade_Level)