namespace Wsh.Mathematics {
    
    public class Vect2Int {
        
        public static readonly Vect2 Zero = new Vect2();
        public static readonly Vect2 One = new Vect2(1, 1);
        public static readonly Vect2 Up = new Vect2(0, 1);
        public static readonly Vect2 Down = new Vect2(0, -1);
        public static readonly Vect2 Left = new Vect2(-1, 0);
        public static readonly Vect2 Right = new Vect2(1, 0);

        public int X => m_x;
        public int Y => m_y;

        public float Magnitude {
            get {
                return MathCalculator.Sqrt(SqrMagnitude);
            }
        }
        
        // 向量的平方长度
        public int SqrMagnitude {
            get {
                return X * X + Y * Y;
            }
        }

        private int m_x;
        private int m_y;
        
        public Vect2Int() : this(0, 0) {

        }

        public Vect2Int(int x, int y) {
            m_x = x;
            m_y = y;
        }

        public void Set(int x, int y) {
            m_x = x;
            m_y = y;
        }

        public void Set(Vect2Int vect) {
            Set(vect.X, vect.Y);
        }

        public void Add(Vect2Int vect) {
            Set(this.X + vect.X, this.Y + vect.Y);
        }

        public void Sub(Vect2Int vect) {
            Set(this.X - vect.X, this.Y - vect.Y);
        }
        
        public void Mul(Vect2Int vect) {
            Set(this.X * vect.X, this.Y * vect.Y);
        }

        public void Mul(int v) {
            Set(this.X * v, this.Y * v);
        }

        public Vect2 Div(float v) {
            return new Vect2(this.X / v, this.Y / v);
        }

        public static Vect2Int operator +(Vect2Int a, Vect2Int b) {
            return new Vect2Int(a.X + b.X, a.Y + b.Y);
        }

        public static Vect2Int operator -(Vect2Int a, Vect2Int b) {
            return new Vect2Int(a.X - b.X, a.Y - b.Y);
        }

        public static Vect2Int operator *(Vect2Int a, Vect2Int b) {
            return new Vect2Int(a.X * b.X, a.Y * b.Y);
        }

        public static Vect2 operator /(Vect2Int a, Vect2Int b) {
            return new Vect2(a.X / (float)b.X, a.Y / (float)b.Y);
        }
    }

}