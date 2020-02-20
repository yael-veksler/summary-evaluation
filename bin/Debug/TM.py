
import nltk
#nltk.download('stopwords')
nltk.download('wordnet')
nltk.download('punkt')
nltk.download('stopwords')
from nltk.tokenize import word_tokenize
from nltk.corpus import stopwords 
from nltk.stem.wordnet import WordNetLemmatizer
lemmatizer = WordNetLemmatizer()
from nltk.stem.snowball import SnowballStemmer
import string
import sys
import re
data= sys.argv[1]
#data= " The Dog Fanciers Club organized a lunch at Sardi's on Wednesday for two of their champions, the city's top police dog and the nation's top show dog.  Nero, a big, amiable bruiser of a German Shepard specializes in sniffing out bombs and narcotics.  He has helped in hundreds of arrests and apprehended more than 50 felons.  Great Elms Prince Charming II is a fluffy little Pomeranian.  He was named best in show at the prestigious Westminister Kennel Club Show in Madison Square Garden last month.  Unfairly, neither Nero nor Prince got any lunch at this prominent midtown restaurant."
#stop = set(stopwords.words('english'))
stop_words = set(stopwords.words(sys.argv[2]))
spanishStemmer=SnowballStemmer(sys.argv[2], ignore_stopwords=True)
#from stop_words import get_stop_words
#stop = get_stop_words(sys.argv[2])
exclude = set(string.punctuation) 
lemmatizer = WordNetLemmatizer()


#data=data.lower()
#data=re.sub(r'\d+', '', data)
#data=data.translate(string.maketrans("",""), string.punctuation)
#data=data.strip()

#tokens = word_tokenize(data)
#doc_clean = [i for i in tokens if not i in stop_words]

#result = [lemmatizer.lemmatize(word) for word in result]
#doc_clean = [spanishStemmer.stem(word).encode("utf-8") for word in doc_clean]

#print(doc_clean)

doc_complete = [data]

doc_clean = [" ".join(spanishStemmer.stem(word) for word in ''.join(ch for ch in " ".join([i for i in doc.lower().split() if i not in stop_words]) if ch not in exclude).split()).split() for doc in doc_complete] 

import gensim
from gensim import corpora

# Creating the term dictionary of our courpus, where every unique term is assigned an index.
dictionary = corpora.Dictionary(doc_clean)

# Converting list of documents (corpus) into Document Term Matrix using dictionary prepared above.
doc_term_matrix = [dictionary.doc2bow(doc) for doc in doc_clean]

# Creating the object for LDA model using gensim library
Lda = gensim.models.ldamodel.LdaModel

# Running and Trainign LDA model on the document term matrix.
ldamodel = Lda(doc_term_matrix, num_topics=10, id2word = dictionary, passes=50)

#print(ldamodel.print_topics(num_topics=10, num_words=1000))

#for idx, topic in ldamodel.print_topics(num_topics=10, num_words=1000):
#    print('Topic: {} \nWords: {}'.format(idx, topic))

for idx, topic in ldamodel.print_topics(num_topics=10, num_words=1000):
    print(topic)





