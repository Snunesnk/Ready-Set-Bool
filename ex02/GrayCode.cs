namespace ReadySetBoole.Ex02 {
    public class GrayCode {
        public static int GetGrayCode(int a) {
            return a ^ (a >> 1);
        }
    }
}