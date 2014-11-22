using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SteamB23.FairyEngine.Components
{
    public class Score : GameComponent, IScoreService
    {
        int rate;
        byte[] numbers;
        bool overFlow = false;
        decimal score = 0;
        decimal scoreTemp = 0;
        decimal scoreTempMirror = 0;
        int frameCount;
        #region 프로퍼티
        public int Rate
        {
            get
            {
                return rate;
            }
        }
        public decimal ToDecimal
        {
            get
            {
                return score;
            }
        }
        public bool OverFlow
        {
            get
            {
                return overFlow;
            }
        }
        #endregion
        public Score(Game game, int rate)
            : this(game, null, rate)
        {
        }
        public Score(Game game, int? length, int rate)
            : base(game)
        {
            this.rate = rate;
            // length에 null이 넘어오면 10으로 바꿔버림. (개인적으로 적당한 수라고 생각됨!)
            if (length == null)
            {
                length = 10;
            }
            // 20은 점수표현의 최대 변수
            if (!(length > 20))
                this.numbers = new byte[(int)length];
            // 게임이 플레이중이 아니라면 업데이트될 필요가 없으므로 Disable
            this.Enabled = false;
        }
        public static Score operator +(Score score, decimal value)
        {
            score.Add(value);
            return score;
        }
        public void Add(decimal value)
        {
            score += value;
        }
        public void Clear()
        {
            this.score = 0;
            this.scoreTemp = 0;
            this.scoreTempMirror = 0;
            this.frameCount = 0;
            for (int i = 0; i < this.numbers.Length; i++)
            {
                numbers[i] = 0;
            }
        }
        public override void Update(GameTime gameTime)
        {
            if (rate <= frameCount++)
            {
                if (score > scoreTemp)
                {
                    #region 스코어 할당 하드코딩
                    var temp = score - scoreTemp;
                    if (temp > 1000)
                        scoreTemp += 1000;
                    else if (temp > 100)
                        scoreTemp += 100;
                    else if (temp > 10)
                        scoreTemp += 10;
                    else
                        scoreTemp++;
                    #endregion
                }
                else if (score < scoreTemp)
                {
                    scoreTemp = score;
                }
                // scoreTemp와 scoreTempMirror가 다르면 numbers를 업데이트 시켜버린다.
                if (scoreTemp != scoreTempMirror)
                {
                    this.NumbersSync();
                }

                frameCount = 0;
            }
            base.Update(gameTime);
        }
        #region numbers 관련 멤버
        public byte this[int value]
        {
            get
            {
                return this.numbers[value];
            }
        }
        public int Length
        {
            get
            {
                return this.numbers.Length;
            }
        }
        void NumbersSync()
        {
            int length = numbers.Length;
            for (int i = 1; i <= length; i++)
            {
                numbers[i] = ChiperCheck(scoreTemp, i);
            }
            // 오버플로 검사
            if (ChiperCheck(scoreTemp, length + 1) > 0)
                overFlow = true;
            else
                overFlow = false;
        }
        byte ChiperCheck(decimal number, int n)
        {
            int chiper;
            if (n > 1)
            {
                // n이 1보다 크다는 것은 자릿수가 2 이상이라는 의미 이므로 10을 대입.
                chiper = 10;
                // n이 2를 초과하면 10을 곱한다.(제곱)
                for (int i = 2; i < n; i++)
                {
                    chiper *= 10;
                }
            }
            else
            {
                chiper = 1;
            }
            return (byte)(number / chiper % 10);
        }
        #endregion
    }
}
