using System;

namespace Wsh.Mathematics {

    public static class ShapeCollision {

        private static Vect2 m_vectTemp01;
        private static Vect2 m_vectTemp02;
        private static Vect2 m_vectTemp03;
        private static Vect2 m_vectTemp04;
        private static Vect2 m_vectTemp05;

        static ShapeCollision() {
            m_vectTemp01 = new Vect2();
            m_vectTemp02 = new Vect2();
            m_vectTemp03 = new Vect2();
            m_vectTemp04 = new Vect2();
            m_vectTemp05 = new Vect2();
        }

        /// <summary>
        /// 判断当前点是否在圆内
        /// </summary>
        /// <param name="point"> 点的坐标 </param>
        /// <param name="circleCenter"> 圆心的坐标 </param>
        /// <param name="circleRadius"> 圆的半径 </param>
        /// <returns></returns>
        public static bool IsPointInCircle(Vect2 point, Vect2 circleCenter, float circleRadius) {
            return (point - circleCenter).SqrMagnitude <= circleRadius * circleRadius;
        }

        /// <summary>
        /// 判断两个圆是否相交（相切）
        /// </summary>
        /// <param name="circleCenter01"> 圆1的圆心 </param>
        /// <param name="circleRadius01"> 圆1的半径 </param>
        /// <param name="circleCenter02"> 圆2的圆心 </param>
        /// <param name="circleRadius02"> 圆2的半径 </param>
        /// <returns></returns>
        public static bool ISCirclesIntersect(Vect2 circleCenter01, float circleRadius01, Vect2 circleCenter02, float circleRadius02) {
            float sum = circleRadius01 + circleRadius02;
            float a = Math.Abs(circleCenter01.X - circleCenter02.X);
            float b = Math.Abs(circleCenter01.Y - circleCenter02.Y);
            if(a >= sum) {
                return false;
            }
            if(b >= sum) {
                return false;
            }
            float d = Math.Abs(circleRadius01 - circleRadius02);
            if (a+b<=d) { // 判断是否大圆包小圆
                return true;
            }
            return (a*a + b*b) <= sum * sum;
            // return (circleCenter01 - circleCenter02).SqrMagnitude <= sum * sum;
        }

        /// <summary>
        /// 判断AABB与圆相交, 算法来源: https://www.zhihu.com/question/24251545/answer/27184960
        /// </summary>
        /// <param name="rectCenter"> 矩形中心点 </param>
        /// <param name="rectWidth"> 矩形宽 </param>
        /// <param name="rectHeight"> 矩形高/长 </param>
        /// <param name="circleCenter"> 圆心坐标 </param>
        /// <param name="circleRadius"> 圆的半径 </param>
        /// <returns></returns>
        public static bool IsAABBCircleIntersect(Vect2 rectCenter, float rectWidth, float rectHeight, Vect2 circleCenter, float circleRadius) {
            m_vectTemp01 = rectCenter - circleCenter;
            m_vectTemp01.Abs();
            m_vectTemp02.Set(rectWidth, rectHeight);
            m_vectTemp02.Div(2f);
            m_vectTemp03 = m_vectTemp01 - m_vectTemp02;
            if(m_vectTemp03.X < 0) {
                m_vectTemp03.SetX(0);
            }
            if(m_vectTemp03.Y < 0) {
                m_vectTemp03.SetY(0);
            }
            return Vect2.Dot(m_vectTemp03, m_vectTemp03) <= circleRadius * circleRadius;
        }

        public static bool IsRectCircleIntersect(Vect2 rectCenter, Vect2 rectDir, float rectWidth, float rectHeight, Vect2 circleCenter, float circleRadius) {
            m_vectTemp01.Set(0, 1);
            float rectRotation = Vect2.SignedAngle(m_vectTemp01, rectDir);
            m_vectTemp02 = circleCenter - rectCenter;
            m_vectTemp02.Rotate(-rectRotation);
            m_vectTemp03.Set(0, 0);
            return IsAABBCircleIntersect(m_vectTemp03, rectWidth, rectHeight, m_vectTemp02, circleRadius);
        }

        public static bool IsRectsIntersect(Vect2 rectCenter01, float rectWidth01, float rectHeight01, Vect2 rectCenter02, float rectWidth02, float rectHeight02) {
            return (MathCalculator.Abs(rectCenter01.X - rectCenter02.X) <= (rectWidth01 + rectWidth02) * 0.5f) && (MathCalculator.Abs(rectCenter01.Y - rectCenter02.Y) <= (rectHeight01 + rectHeight02) * 0.5f);
        }

    }
}