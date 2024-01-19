namespace ReadySetBoole.Ex00 {
    public class Adder {
        public static int Add(int a, int b) {
            int result = 0;
            int temp_result = 0;
            int temp_a;
            int temp_b;
            int mask = 1;
            int count = 0;
            int ret = 0;

            // Go throught each bit
            while (count < 32) {
                // Get current bit value in both numbers
                temp_a = a & mask;
                temp_b = b & mask;

                // Check if we'll need a carry over
                if ((temp_a ^ temp_b) != (temp_a | temp_b))
                    ret = 1;

                temp_result = temp_a ^ temp_b;
                // If XOR is different from OR, it means that we need to keep carrying 1
                if ((temp_result ^ result) != (temp_result | result))
                    ret = 1;
                result = temp_result ^ result;

                mask = mask << 1;
                count++;

                // Apply carry over
                if (ret == 1)
                {
                    // The carry over corresponds to the current mask
                    result = mask ^ result;
                    // If the current bit in the result is a 1, then there's no more need for the carry over
                    if ((mask & result) == mask)
                        ret = 0;
                }
            }

            return result;
        }
    }
}