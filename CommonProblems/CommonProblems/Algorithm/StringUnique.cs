public class StringUnique {
	public const string Alphabet = "QWERTYUIOPASDFGHJKLZXCVBNM";

	bool isUnique(string str) {
		if (string.IsNullOrEmpty(str)) {
			return false;
		}
		HashTable<char, int> charsMap = new HashTable<char,int>();
		
		char[] chars = Alphabet.ToCharArray();
		
		//store the count of each character
		for(int i =0; i< chars.Length ; i++){
			for(int j= 0; j< str.Length; j++){
				if (charsMap[chars[j]] == null){
					charsMap[chars[j]] = 1;
				}
				else {
					charsMapp[chars[j]] += 1;
				}
			}			
		}
		
		//check if any char is missing
		for(int i =0; i< chars.Length ; i++){
			if (charsMap[chars[i]] < 1) {
				return false;
			}
		}
		
		return true;
	}
}