using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DragonsWay.Logic
{
    public class Game
    {
        private char[,] _cavern;
        private bool _win;

        public Game(int n, string path) 
        {
            N = n + 1;
            M = (n * 2) + 1;
            Path = path;
            _cavern = new char[N, M];
            FillCavern();
            Win = Solution(path);
        }


        public int N { get; }

        public int M { get; }

        private char[,] Cavern { set => _cavern = value; }

        public string Path { get; }

        public bool Win { set => _win = value; get => _win; }

        public override string ToString()
        {
            var output = string.Empty;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    output += $"{_cavern[i, j]}";
                }
                output += "\n";
            }
            return output;
        }

        private void FillCavern()
        {
            FillBorders();
        }

        private void FillBorders()
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    _cavern[i, j] = ' ';
                }
            }
            for (int i = 0, j = -1; i < N; i++, j++)
            {
                switch (j)
                {
                    case -1:
                        _cavern[i, 0] = ' ';
                        break;
                    case 0:
                        _cavern[i, 0] = '0';
                        break;
                    case 1:
                        _cavern[i, 0] = '1';
                        break;
                    case 2:
                        _cavern[i, 0] = '2';
                        break;
                    case 3:
                        _cavern[i, 0] = '3';
                        break;
                    case 4:
                        _cavern[i, 0] = '4';
                        break;
                    case 5:
                        _cavern[i, 0] = '5';
                        break;
                    case 6:
                        _cavern[i, 0] = '6';
                        break;
                    case 7:
                        _cavern[i, 0] = '7';
                        break;
                    case 8:
                        _cavern[i, 0] = '8';
                        break;
                    case 9:
                        _cavern[i, 0] = '9';
                        j = -1;
                        break;
                }
            }
            for (int i = 0, j = -1; i < M; i++, j++)
            {
                switch (j)
                {
                    case -1:
                        _cavern[0, i] = ' ';
                        break;
                    case 0:
                        _cavern[0, i] = '0';
                        break;
                    case 1:
                        _cavern[0, i] = '1';
                        break;
                    case 2:
                        _cavern[0, i] = '2';
                        break;
                    case 3:
                        _cavern[0, i] = '3';
                        break;
                    case 4:
                        _cavern[0, i] = '4';
                        break;
                    case 5:
                        _cavern[0, i] = '5';
                        break;
                    case 6:
                        _cavern[0, i] = '6';
                        break;
                    case 7:
                        _cavern[0, i] = '7';
                        break;
                    case 8:
                        _cavern[0, i] = '8';
                        break;
                    case 9:
                        _cavern[0, i] = '9';
                        j = -1;
                        break;
                }
            }
            for (int i = 1; i < M; i++)
            {
                _cavern[1, i] = '█';
            }
            _cavern[2, M - 1] = '█';
            for (int i = 3; i < N - 2; i++)
            {
                _cavern[i, 1] = '█';
                _cavern[i, M - 1] = '█';
            }
            _cavern[N - 2, 1] = '█';
            for (int i = 1; i < M; i++)
            {
                _cavern[N - 1, i] = '█';
            }
        }

        private bool Solution(string path)
        {
            for (int k = 0, i = 2, j = 1; k < path.Length; k++)
            {
                if (path[k] != '↓' && path[k] != '→')
                {
                    throw new Exception("The path is not valid.");
                }
                else
                {
                    if (i < N - 1 && j < M - 1)
                    {
                        if (path[k] == '→')
                        {
                            if (_cavern[i, j + 1] == '█')
                            {
                                return false;
                            }
                            _cavern[i, j] = '→';
                            j++;
                        }
                        else
                        {
                            if (_cavern[i + 1, j] == '█')
                            {
                                return false;
                            }
                            _cavern[i, j] = '↓';
                            i++;
                        }
                    }
                }
            }
            if (_cavern[N - 2, M - 2] != '↓' && _cavern[N - 2, M - 2] != '→')
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
