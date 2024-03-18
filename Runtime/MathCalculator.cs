using System;

namespace Wsh.Mathematics {

    public static class MathCalculator {

        // 自然对数的底数 2.7182818284590451
        public const float E = (float)Math.E;

        // 3.1415926535897931
        public const float PI = (float)Math.PI;

        // 平角的大小
        public const float FLAT_ANGLE_DEGREE = 180f;

        // 正无穷大的数
        public const float POSITIVE_INFINITY = float.PositiveInfinity;

        // 负无穷大的数
        public const float NEGATIVE_INFINITY = float.NegativeInfinity;

        // 角度到弧度的转换常数 0.017453292
        public const float DEGREE_TO_RADIAN = PI / FLAT_ANGLE_DEGREE;

        // 弧度到角度的转换常数 57.29578
        public const float RADIAN_TO_DEGREE = FLAT_ANGLE_DEGREE / PI;

        public static float DegreeToRadian(float degree) {
            return degree * DEGREE_TO_RADIAN;
        }

        public static float RadianToDegree(float radian) {
            return radian * RADIAN_TO_DEGREE;
        }

        // 三角函数 正弦值, 输入的是弧度
        public static float Sin(float radian) {
            return (float)Math.Sin(radian);
        }

        // 反正弦函数, 输入的是正弦值[-1, 1]，返回的是对应的弧度
        public static float Asin(float value) {
            return (float)Math.Asin(value);
        }

        // 三角函数 余弦值, 输入的是弧度
        public static float Cos(float radian) {
            return (float)Math.Cos(radian);
        }

        // 反余弦函数, 输入的是余弦值[-1, 1]，返回的是对应的弧度
        public static float Acos(float value) {
            return (float)Math.Acos(value);
        }

        // 三角函数 正切值, 输入的是弧度
        public static float Tan(float radian) {
            return (float)Math.Tan(radian);
        }

        // 反正切函数, 输入的是正切值，返回的是对应的弧度
        public static float Atan(float value) {
            return (float)Math.Atan(value);
        }

        /// <summary>
        /// 这是一个四象限反正切函数，它接收两个参数：y坐标值和x坐标值；
        /// 通常用来计算从原点到点 (x, y) 的角度，其中角度是在平面笛卡尔坐标系中的终边与x轴正方向之间的夹角，范围是从 -π 到 π 弧度。
        /// Math.Atan2() 的优势在于它能根据两点间的坐标直接计算出准确的角度，
        /// 而不像 Math.Atan() 需要额外的信息来判断象限。即使当 x = 0 而 y 不为零时（即垂直方向上的点），也能正确地计算角度。
        /// </summary>
        /// <param name="y"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float Atan2(float y, float x) {
            return (float)Math.Atan2(y, x);
        }

        // 开平方根的函数
        public static float Sqrt(float value) {
            return (float)Math.Sqrt(value);
        }

        // 计算绝对值
        public static float Abs(float value) {
            return (float)Math.Abs(value);
        }

        // int 类型的重载 计算绝对值
        public static int Abs(int value) {
            return Math.Abs(value);
        }

        // 返回最小值
        public static float Min(float a, float b) {
            return Math.Min(a, b);
        }

        // int 类型的重载，计算最小值
        public static int Min(int a, int b) {
            return Math.Min(a, b);
        }

        // 从多个数中算出最小值
        public static float Min(params float[] values) {
            int num = values.Length;
            if(num == 0) {
                return 0f;
            }
            float v = values[0];
            for(int i = 1; i < num; i++) {
                if(values[i] < v) {
                    v = values[i];
                }
            }
            return v;
        }

        // int 类型的重载 从多个数中算出最小值
        public static int Min(params int[] values) {
            int num = values.Length;
            if(num == 0) {
                return 0;
            }
            int v = values[0];
            for(int i = 1; i < num; i++) {
                if(values[i] < v) {
                    v = values[i];
                }
            }
            return v;
        }

        // 返回最大值
        public static float Max(float a, float b) {
            return Math.Max(a, b);
        }

        // int 类型的重载
        public static int Max(int a, int b) {
            return Math.Max(a, b);
        }

        // 从多个数中算出最大值
        public static float Max(params float[] values) {
            int num = values.Length;
            if(num == 0) {
                return 0f;
            }
            float v = values[0];
            for(int i = 1; i < num; i++) {
                if(values[i] > v) {
                    v = values[i];
                }
            }
            return v;
        }

        // int 类型的重载 从多个数中算出最大值
        public static int Max(params int[] values) {
            int num = values.Length;
            if(num == 0) {
                return 0;
            }
            int v = values[0];
            for(int i = 1; i < num; i++) {
                if(values[i] > v) {
                    v = values[i];
                }
            }
            return v;
        }

        // 返回 v 的 p 次方
        public static float Pow(float v, float p) {
            return (float)Math.Pow(v, p);
        }

        // 计算自然对数的底数(e 约等于 2.7182818284590451)的多少次方
        public static float Exp(float p) {
            return (float)Math.Exp(p);
        }

        /// <summary>
        /// 以底数 p 为底的对数
        /// p 为任何实数
        /// Math.Log(100, 10) = 2 
        /// 10 的 2 次方 = 100
        /// </summary>
        /// <param name="v"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static float Log(float v, float p) {
            return (float)Math.Log(v, p);
        }

        /// <summary>
        /// 是以自然对数的底数 e（约为 2.71828）为底的对数
        /// Math.Log(10) = 2.302585092994046
        /// e 的 2.302585092994046 次方就等于10
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static float Log(float v) {
            return (float)Math.Log(v);
        }

        /// <summary>
        /// 以底数 10 为底的对数
        /// Log10（100） = 2
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static float Log10(float v) {
            return (float)Math.Log10(v);
        }

        /// <summary>
        /// 计算一个数的上界
        /// 返回不小于这个数的最小整数
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static float Ceiling(float v) {
            return (float)Math.Ceiling(v);
        }

        public static int CeilingToInt(float v) {
            return (int)Math.Ceiling(v);
        }

        /// <summary>
        /// 计算一个数的下界
        /// 返回不大于这个数的最大整数
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static float Floor(float v) {
            return (float)Math.Floor(v);
        }

        public static int FloorToInt(float v) {
            return (int)Math.Floor(v);
        }

        // 四舍五入的算法
        public static float Round(float v) {
            return (float)Math.Round(v);
        }

        public static int RoundToInt(float v) {
            return (int)Math.Round(v);
        }

        public static float Sign(float v) {
            return (float)Math.Sign(v);
        }

        // value 的取值在 min max之间，超出这个边界会返回对应边界的值
        public static float Clamp(float value, float min, float max) {
            if(value < min) {
                value = min;
            } else if(value > max) {
                value = max;
            }
            return value;
        }

        public static int Clamp(int value, int min, int max) {
            if(value < min) {
                value = min;
            } else if(value > max) {
                value = max;
            }
            return value;
        }

    }

}