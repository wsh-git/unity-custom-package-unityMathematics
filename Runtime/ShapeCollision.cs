using UnityEngine;

namespace Wsh.Mathematics {

    public static class ShapeCollision {

        private static Vector2 m_vectTemp01;
        private static Vector2 m_vectTemp02;
        private static Vector2 m_vectTemp03;
        private static Vector2 m_vectTemp04;
        private static Vector2 m_vectTemp05;

        static ShapeCollision() {
            m_vectTemp01 = new Vector2(0, 0);
            m_vectTemp02 = new Vector2(0, 0);
            m_vectTemp03 = new Vector2(0, 0);
            m_vectTemp04 = new Vector2(0, 0);
            m_vectTemp05 = new Vector2(0, 0);
        }

        private static float Dot(Vector2 vector1, Vector2 vector2) {
            return vector1.x * vector2.x + vector1.y * vector2.y;
        }

        private static void Abs(this Vector2 vector) {
            vector.x = Mathf.Abs(vector.x);
            vector.y = Mathf.Abs(vector.y);
        }

        private static void Rotate(this Vector2 vector, float angle) {
            float radian = DegreeToRadian(angle);
            float sin = Mathf.Sin(radian);
            float cos = Mathf.Cos(radian);
            vector.x = vector.x * cos - vector.y * sin;
            vector.y = vector.y * cos + vector.x * sin;
        }

        private static float DegreeToRadian(float angle) {
            return angle * Mathf.Deg2Rad;
        }

        private static float RadianToDegree(float radian) {
            return radian * Mathf.Rad2Deg;
        }

        /// <summary>
        /// 判断当前点是否在圆内
        /// </summary>
        /// <param name="point"> 点的坐标 </param>
        /// <param name="circleCenter"> 圆心的坐标 </param>
        /// <param name="circleRadius"> 圆的半径 </param>
        /// <returns></returns>
        public static bool IsPointInCircle(Vector2 point, Vector2 circleCenter, float circleRadius) {
            return Vector2.SqrMagnitude(point - circleCenter) <= circleRadius * circleRadius;
        }

        /// <summary>
        /// 判断两个圆是否相交（相切）
        /// </summary>
        /// <param name="circleCenter01"> 圆1的圆心 </param>
        /// <param name="circleRadius01"> 圆1的半径 </param>
        /// <param name="circleCenter02"> 圆2的圆心 </param>
        /// <param name="circleRadius02"> 圆2的半径 </param>
        /// <returns></returns>
        public static bool ISCirclesIntersect(Vector2 circleCenter01, float circleRadius01, Vector2 circleCenter02, float circleRadius02) {
            float sum = circleRadius01 + circleRadius02;
            return Vector2.SqrMagnitude(circleCenter01 - circleCenter02) <= sum * sum;
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
        public static bool IsAABBCircleIntersect(Vector2 rectCenter, float rectWidth, float rectHeight, Vector2 circleCenter, float circleRadius) {
            m_vectTemp01 = rectCenter - circleCenter;
            m_vectTemp01.Abs();
            m_vectTemp02.Set(rectWidth, rectHeight);
            m_vectTemp02 = m_vectTemp02 / 2f;
            m_vectTemp03 = m_vectTemp01 - m_vectTemp02;
            if(m_vectTemp03.x < 0) {
                m_vectTemp03.x = 0;
            }
            if(m_vectTemp03.y < 0) {
                m_vectTemp03.y = 0;
            }
            return Dot(m_vectTemp03, m_vectTemp03) <= circleRadius * circleRadius;
        }

        public static bool IsRectCircleIntersect(Vector2 rectCenter, Vector2 rectDir, float rectWidth, float rectHeight, Vector2 circleCenter, float circleRadius) {
            m_vectTemp01.Set(0, 1);
            float rectRotation = Vector2.SignedAngle(m_vectTemp01, rectDir);
            m_vectTemp02 = circleCenter - rectCenter;
            m_vectTemp02.Rotate(-rectRotation);
            circleCenter.Set(m_vectTemp02.x, m_vectTemp02.y);
            rectCenter.Set(0, 0);
            return IsAABBCircleIntersect(rectCenter, rectWidth, rectHeight, circleCenter, circleRadius);
        }

    }
}