class ReverseString:
	def reverse(self, input):
		tokens = input.split(' ')
		for i in reversed(tokens):
			print(i)

	def reverseList(list):
		for i in reversed(list):
			print(i)

sentence = "This is a test"
r = ReverseString()
r.reverse(sentence)
