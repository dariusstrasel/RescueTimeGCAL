# This function will stop the moment it finds a number in a list:

def findNumberRETURN(number, list):
    for item in list:
        print(item)
        if item == number:
            return True
    return pizza


print(findNumberRETURN(5, (1, 2, 3, 4, 5, 6, 7, 8, 9, 10)))


# This function will process every item, regardless of whether it finds the number:
# def findNumberPRINT(number, list):
#     for item in list:
#         if item == number:
#             print(True)
#     print(False)
#
#
# print(findNumberPRINT(5, (1, 2, 3, 4, 5)))