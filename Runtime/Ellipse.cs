namespace Wsh.Mathematics {
    
    public class Ellipse {

        public float RadiusX { get; private set; }
        public float RadiusY { get; private set; }
        public bool IsFinish => m_addAngle > MathCalculator.FULL_ANGLE_DEGREE;
        
        private Vect2 m_offset;
        private int m_angleSpace;
        private Vect2 m_tempPosition;
        private int m_addAngle;
        private int m_angle;
        private float m_radian;

        public Ellipse(int originAngle, float radiusX, float radiusY, int angleSpace, Vect2 offset) {
            RadiusX = radiusX;
            RadiusY = radiusY;
            m_offset = new Vect2(offset.X, offset.Y);
            m_angleSpace = angleSpace;
            m_tempPosition = new Vect2();
            m_angle = originAngle;
            m_addAngle = 0;
            m_radian = 0;
        }

        public Vect2 Next() {
            if(IsFinish) {
                m_tempPosition.Set(m_offset.X, m_offset.Y);
            } else {
                m_radian = MathCalculator.DegreeToRadian(m_angle);
                m_angle += m_angleSpace;
                m_addAngle += MathCalculator.Abs(m_angleSpace);
                m_tempPosition.Set( RadiusX * MathCalculator.Cos(m_radian) + m_offset.X, RadiusY * MathCalculator.Sin(m_radian) + m_offset.Y);
            }
            return m_tempPosition;
        }
        
    }
    
}