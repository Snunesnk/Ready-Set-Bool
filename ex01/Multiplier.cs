using ReadySetBoole.Ex00;

namespace ReadySetBoole.Ex01 {
    public class Multiplayer {
        public static int Multiply(int a, int b) {
            int result = a;
            int count = 1;

            while (count < b) {
                result = Adder.Add(result, a);
                count++;
            }
            return result;
        }
    }
}