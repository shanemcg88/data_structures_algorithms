word_1 = "bonsor"
word_2 = "robson"

def is_anagram(str1, str2):
    if len(str1) != len(str2):
        return False
    
    str1 = sorted(str1)
    str2 = sorted(str2)

    for i in range(len(str1)):
        if str1[i] != str2[i]:
            return False
    
    return True

print(is_anagram(word_1, word_2))
