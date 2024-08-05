namespace Wsh.Mathematics {
    
    public class Vect2 {
        
        public static readonly Vect2 Zero = new Vect2();
        public static readonly Vect2 One = new Vect2(1f);
        public static readonly Vect2 Up = new Vect2(0f, 1f);
        public static readonly Vect2 Down = new Vect2(0f, -1f);
        public static readonly Vect2 Left = new Vect2(-1f, 0f);
        public static readonly Vect2 Right = new Vect2(1f, 0f);

        public float X => m_x;
        public float Y => m_y;

        public float Magnitude {
            get {
                return MathCalculator.Sqrt(SqrMagnitude);
            }
        }
        
        // 向量的平方长度
        public float SqrMagnitude {
            get {
                return X * X + Y * Y;
            }
        }

        private float m_x;
        private float m_y;
        
        public Vect2() : this(0) {

        }

        public Vect2(Vect2Int vect2Int) : this((float)vect2Int.X, (float)vect2Int.Y) {

        }

        public Vect2(float v) : this(v, v) {

        }

        public Vect2(float x, float y) {
            m_x = x;
            m_y = y;
        }

        public void Set(float x, float y) {
            m_x = x;
            m_y = y;
        }

        public void SetX(float x) {
            m_x = x;
        }

        public void SetY(float y) {
            m_y = y;
        }

        public void Set(Vect2 vect) {
            Set(vect.X, vect.Y);
        }

        public void Set(float v) {
            Set(v, v);
        }

        public Vect2 Copy() {
            return new Vect2(X, Y);
        }

        public override string ToString() {
            return $"({X}, {Y})";
        }

        public void Add(Vect2 vect) {
            Set(this.X + vect.X, this.Y + vect.Y);
        }

        public void Sub(Vect2 vect) {
            Set(this.X - vect.X, this.Y - vect.Y);
        }
        
        public void Mul(Vect2 vect) {
            Set(this.X * vect.X, this.Y * vect.Y);
        }

        public void Mul(float v) {
            Set(this.X * v, this.Y * v);
        }

        public void Div(Vect2 vect) {
            Set(this.X / vect.X, this.Y / vect.Y);
        }

        public void Div(float v) {
            Set(this.X / v, this.Y / v);
        }

        public void Abs() {
            Set(MathCalculator.Abs(this.X), MathCalculator.Abs(this.Y));
        }
        
        public void Normalize() {
            float num = Magnitude;
            if(num > 1E-05f) {
                Div(num);
            } else {
                Set(0);
            }
        }

        /// <summary>
        /// 当前向量按照 角度 degree 进行旋转
        /// </summary>
        /// <param name="degree">角度（注意：这里不是弧度）</param>
        public void Rotate(float degree) {
            float radian = MathCalculator.DegreeToRadian(degree);
            float sin = MathCalculator.Sin(radian);
            float cos = MathCalculator.Cos(radian);
            float newX = X * cos - Y * sin;
            float newY = Y * cos + X * sin;
            Set(newX, newY);
        }
        
        public static float SqrDistance(Vect2 vect1, Vect2 vect2) {
            float x = vect1.X - vect2.X;
            float y = vect1.Y - vect2.Y;
            return x * x + y * y;
        }
        
        public static float Dot(Vect2 vect1, Vect2 vect2) {
            return vect1.X * vect2.X + vect1.Y * vect2.Y;
        }

        /// <summary>
        /// 计算从向量1到向量2的角度
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns> 注意：这里返回的是角度，不是弧度 </returns>
        public static float Angle(Vect2 from, Vect2 to) {
            float num = MathCalculator.Sqrt(from.SqrMagnitude * to.SqrMagnitude);
            if(num < 1E-15f) {
                return 0f;
            }
            float num2 = MathCalculator.Clamp(Dot(from, to)/num, -1f, 1f);
            return MathCalculator.RadianToDegree(MathCalculator.Acos(num2));
        }

        public static float SignedAngle(Vect2 from, Vect2 to) {
            float num1 = Angle(from, to);
            float num2 = MathCalculator.Sign(from.X * to.Y - from.Y * to.X);
            return num1 * num2;
        }

        public static Vect2 operator +(Vect2 a, Vect2 b) {
            return new Vect2(a.X + b.X, a.Y + b.Y);
        }

        public static Vect2 operator -(Vect2 a, Vect2 b) {
            return new Vect2(a.X - b.X, a.Y - b.Y);
        }

        public static Vect2 operator *(Vect2 a, Vect2 b) {
            return new Vect2(a.X * b.X, a.Y * b.Y);
        }

        public static Vect2 operator /(Vect2 a, Vect2 b) {
            return new Vect2(a.X / b.X, a.Y / b.Y);
        }
    }

}