duplicates = [2,2,2,3,3,5,6,6,7] 

# 0(N) linear running time
def find_duplicates(nums):
    for num in nums:
        if nums[abs(num)] >= 0:
            nums[abs(num)] = -nums[abs(num)]
        else:
            print('repitiion found: %s' % str(abs(num)))


print(find_duplicates(duplicates))