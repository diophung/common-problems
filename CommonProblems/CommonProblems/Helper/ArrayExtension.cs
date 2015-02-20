using System;

namespace CommonProblems.Helper {
	public static class ArrayExtension {
		public static bool ElementEquals(this int[] a, int[] b) {
			try {
				for (int i = 0; i < a.Length; i++) {
					if (a[i] != b[i]) return false;
				}
			}
			catch (Exception) {
				return false;
			}

			return true;
		}

		public static bool IsSortedAsc(this int[] arr) {
			if (arr == null || arr.Length <= 1) {
				return true;
			}

			for (int i = 0; i < arr.Length - 1; i++) {
				if (arr[i].CompareTo(arr[i + 1]) > 0) {
					return false;
				}
			}
			return true;
		}
	}
}
