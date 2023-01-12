//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;

//namespace TaskExam
//{
//    internal class TaskSolver
//    {
//        public static void Main(string[] args)
//        {
//            TestGenerateWordsFromWord();
//            TestMaxLengthTwoChar();
//            TestGetPreviousMaxDigital();
//            TestSearchQueenOrHorse();
//            TestCalculateMaxCoins();

//            Console.WriteLine("All Test completed!");
//        }

//        /// задание 1) Слова из слова

//        public static List<string> GenerateWordsFromWord(string word, List<string> wordDictionary)
//        {
//            List<string> answerDictionary = new List<string>();

//            foreach (string wordFromDictionary in wordDictionary)
//            {
//                if (FindWord(word, wordFromDictionary))
//                    answerDictionary.Add(wordFromDictionary);
//            }
//            answerDictionary.Sort();

//            return answerDictionary;
//        }

//        private static bool FindWord(string word, string searchingWord)
//        {
//            BitArray isChapterUsed = new BitArray(word.Length, false);
//            foreach (char chapter in searchingWord)
//            {
//                bool isChapterAdd = false;
//                for (int i = 0; i < word.Length; i++)
//                {
//                    if (word[i] == chapter && !isChapterUsed[i])
//                    {
//                        isChapterUsed[i] = true;
//                        isChapterAdd = true;
//                        break;
//                    }
//                }
//                if (!isChapterAdd) return false;
//            }
//            return true;
//        }

//        /// задание 2) Два уникальных символа

//        public static int MaxLengthTwoChar(string word)
//        {
//            int maxValueForAnswer = 0;

//            List<char> chapters = new List<char>();
//            chapters.Add(word[0]);
//            foreach (char chapter in word)
//            {
//                bool isChapterDoesntExistsInList = true;
//                foreach (char singleChapter in chapters)
//                {
//                    if (singleChapter == chapter)
//                        isChapterDoesntExistsInList = false;
//                }
//                if (isChapterDoesntExistsInList)
//                {
//                    chapters.Add(chapter);
//                }
//            }

//            if (chapters.Count == 1)
//                return 0;

//            if (chapters.Count == 2)
//                if (IsStringFits(word)) return word.Length;
//                else return 0;

//            for (int i = 0; i < chapters.Count - 1; i++)
//                for (int j = i + 1; j < chapters.Count; j++)
//                {
//                    string temporaryString = DeleteAllExcept(word, chapters[i], chapters[j]);

//                    if (IsStringFits(temporaryString))
//                        if (temporaryString.Length > maxValueForAnswer)
//                            maxValueForAnswer = temporaryString.Length;
//                }

//            return maxValueForAnswer;
//        }

//        private static bool IsStringFits(string word)
//        {
//            for (int i = 1; i < word.Length; i++)
//            {
//                if (word[i] == word[i - 1]) return false;
//            }
//            return true;
//        }

//        private static string DeleteAllExcept(string word, char chapterA, char chapterB)
//        {
//            string answer = "";
//            for (int i = 0; i < word.Length; i++)
//            {
//                if (word[i] == chapterA || word[i] == chapterB)
//                    answer += word[i];
//            }

//            return answer;
//        }

//        /// задание 3) Предидущее число

//        public static long GetPreviousMaxDigital(long value)
//        {
//            string temporaryString = new string(value.ToString());
//            List<string> answers = new List<string>();
//            GetAllPermutations(temporaryString, 0, temporaryString.Length - 1, answers);
//            answers.Sort();
//            for (int i = 0; i < answers.Count; i++)
//            {
//                if (value <= Convert.ToInt32(answers[i]))
//                {
//                    if (i == 0) return -1;
//                    if (answers[i - 1][0] == '0') return -1;
//                    else
//                        return Convert.ToInt32(answers[i - 1]);
//                }
//            }
//            //код алгоритма
//            return -1;
//        }

//        private static void GetAllPermutations(string variant, int left, int right, List<string> answers)
//        {
//            if (left == right)
//            {
//                answers.Add(variant);
//            }
//            else
//            {
//                for (int i = left; i <= right; i++)
//                {
//                    variant = Swap(variant, left, i);
//                    GetAllPermutations(variant, left + 1, right, answers);
//                    variant = Swap(variant, left, i);
//                }
//            }
//        }

//        public static string Swap(string str, int i, int j)
//        {
//            var charArray = str.ToCharArray();
//            char temp = charArray[i];
//            charArray[i] = charArray[j];
//            charArray[j] = temp;
//            return new String(charArray);
//        }

//        /// задание 4) Конь и Королева

//        public struct Point
//        {
//            public int i;
//            public int j;
//            public Point()
//            {
//                i = 0;
//                j = 0;
//            }
//            public Point(int x, int y)
//            {
//                i = x;
//                j = y;
//            }
//        }

//        public static void QueenTurns(Point startPoint, char[][] gridMap, int[][] turnMap)
//        {
//            Queue<Point> turnQueue = new Queue<Point>();
//            turnQueue.Enqueue(startPoint);
//            int rows = gridMap.Length;
//            int colluns = gridMap[0].Length;
//            while (turnQueue.TryDequeue(out Point checkingPoint))
//            {
//                bool[] isDurationAvailible = new bool[8];
//                for (int i = 0; i < 8; i++)
//                {
//                    isDurationAvailible[i] = true;
//                }
//                for (int i = 1; i < Math.Max(rows, colluns); i++)
//                {
//                    CheckPositionForQueen(checkingPoint, new Point(i, -i), gridMap, turnMap, turnQueue, ref isDurationAvailible[0]);
//                    CheckPositionForQueen(checkingPoint, new Point(i, 0), gridMap, turnMap, turnQueue, ref isDurationAvailible[1]);
//                    CheckPositionForQueen(checkingPoint, new Point(i, i), gridMap, turnMap, turnQueue, ref isDurationAvailible[2]);
//                    CheckPositionForQueen(checkingPoint, new Point(-i, -i), gridMap, turnMap, turnQueue, ref isDurationAvailible[3]);
//                    CheckPositionForQueen(checkingPoint, new Point(-i, 0), gridMap, turnMap, turnQueue, ref isDurationAvailible[4]);
//                    CheckPositionForQueen(checkingPoint, new Point(-i, i), gridMap, turnMap, turnQueue, ref isDurationAvailible[5]);
//                    CheckPositionForQueen(checkingPoint, new Point(0, -i), gridMap, turnMap, turnQueue, ref isDurationAvailible[6]);
//                    CheckPositionForQueen(checkingPoint, new Point(0, i), gridMap, turnMap, turnQueue, ref isDurationAvailible[7]);
//                }
//            }
//        }

//        public static void CheckPositionForQueen(Point position, Point duration, char[][] gridMap, int[][] turnMap, Queue<Point> turnQueue, ref bool isDurationAvailible)
//        {
//            if (isDurationAvailible)
//            {
//                int rows = gridMap.Length;
//                int collums = gridMap[0].Length;
//                if ((position.j + duration.j < collums && position.i + duration.i < rows) && (position.j + duration.j >= 0 && position.i + duration.i >= 0))
//                {
//                    if (gridMap[position.i + duration.i][position.j + duration.j] == 'x')
//                    {
//                        isDurationAvailible = false;
//                    }
//                    else
//                    {
//                        if (turnMap[position.i + duration.i][position.j + duration.j] == 0)
//                        {
//                            if ((position.j - duration.j < collums && position.i - duration.i < rows) && (position.j - duration.j >= 0 && position.i - duration.i >= 0))
//                            {
//                                if (turnMap[position.i - duration.i][position.j - duration.j] != 0)
//                                {
//                                    if (turnMap[position.i][position.j] < turnMap[position.i][position.j] + 1)
//                                    {
//                                        turnMap[position.i + duration.i][position.j + duration.j] = turnMap[position.i][position.j];
//                                        turnQueue.Enqueue(new Point(position.i + duration.i, position.j + duration.j));
//                                    }
//                                }
//                                else
//                                {
//                                    turnMap[position.i + duration.i][position.j + duration.j] = turnMap[position.i][position.j] + 1;
//                                    turnQueue.Enqueue(new Point(position.i + duration.i, position.j + duration.j));
//                                }
//                            }
//                            else
//                            {
//                                turnMap[position.i + duration.i][position.j + duration.j] = turnMap[position.i][position.j] + 1;
//                                turnQueue.Enqueue(new Point(position.i + duration.i, position.j + duration.j));
//                            }

//                        }
//                    }
//                }
//                else
//                {
//                    isDurationAvailible = false;
//                }
//            }
//        }

//        public static void HorseTurns(Point startPoint, char[][] gridMap, int[][] turnMap)
//        {
//            Queue<Point> turnQueue = new Queue<Point>();
//            turnQueue.Enqueue(startPoint);
//            int rows = gridMap.Length;
//            int colluns = gridMap[0].Length;
//            while (turnQueue.TryDequeue(out Point checkingPoint))
//            {
//                CheckPositionForHorse(checkingPoint, new Point(2, 1), gridMap, turnMap, turnQueue);
//                CheckPositionForHorse(checkingPoint, new Point(2, -1), gridMap, turnMap, turnQueue);
//                CheckPositionForHorse(checkingPoint, new Point(1, 2), gridMap, turnMap, turnQueue);
//                CheckPositionForHorse(checkingPoint, new Point(1, -2), gridMap, turnMap, turnQueue);
//                CheckPositionForHorse(checkingPoint, new Point(-2, 1), gridMap, turnMap, turnQueue);
//                CheckPositionForHorse(checkingPoint, new Point(-2, -1), gridMap, turnMap, turnQueue);
//                CheckPositionForHorse(checkingPoint, new Point(-1, 2), gridMap, turnMap, turnQueue);
//                CheckPositionForHorse(checkingPoint, new Point(-1, -2), gridMap, turnMap, turnQueue);
//            }
//        }

//        public static void CheckPositionForHorse(Point position, Point duration, char[][] gridMap, int[][] turnMap, Queue<Point> turnQueue)
//        {
//            if ((position.j + duration.j < gridMap[0].Length && position.i + duration.i < gridMap.Length) && (position.j + duration.j >= 0 && position.i + duration.i >= 0))
//                if (turnMap[position.i + duration.i][position.j + duration.j] == 0 && gridMap[position.i + duration.i][position.j + duration.j] != 'x')
//                {
//                    turnMap[position.i + duration.i][position.j + duration.j] = turnMap[position.i][position.j] + 1;
//                    turnQueue.Enqueue(new Point(position.i + duration.i, position.j + duration.j));
//                }
//        }

//        public static List<int> SearchQueenOrHorse(char[][] gridMap)
//        {
//            Point startPoint = new Point();
//            Point endPoint = new Point();
//            for (int i = 0; i < gridMap.Length; i++)
//            {
//                for (int j = 0; j < gridMap[i].Length; j++)
//                {
//                    if (gridMap[i][j] == 's')
//                    {
//                        startPoint = new Point(i, j);
//                    }
//                    if (gridMap[i][j] == 'e')
//                    {
//                        endPoint = new Point(i, j);
//                    }
//                }
//            }

//            int[][] queenTurnMap = new int[gridMap.Length][];
//            for (int i = 0; i < gridMap.Length; i++)
//                queenTurnMap[i] = new int[gridMap[0].Length];
//            queenTurnMap[startPoint.i][startPoint.j] = 1;

//            int[][] horseTurnMap = new int[gridMap.Length][];
//            for (int i = 0; i < gridMap.Length; i++)
//                horseTurnMap[i] = new int[gridMap[0].Length];
//            horseTurnMap[startPoint.i][startPoint.j] = 1;

//            QueenTurns(startPoint, gridMap, queenTurnMap);
//            HorseTurns(startPoint, gridMap, horseTurnMap);

//            //код алгоритма
//            return new List<int> { horseTurnMap[endPoint.i][endPoint.j] - 1, queenTurnMap[endPoint.i][endPoint.j] - 1 };
//        }

//        /// задание 5) Жадина
//        public static long CalculateMaxCoins(int[][] mapData, int idStart, int idFinish)
//        {
//            int cityAmount = 0;
//            for (int i = 0;i<mapData.Length;i++)
//            {
//                if (mapData[i][0] > cityAmount)
//                    cityAmount = mapData[i][0];
//                if (mapData[i][1] > cityAmount)
//                    cityAmount = mapData[i][1];
//            }
//            cityAmount++;
//            BitArray isWeDontBurnThisCity = new BitArray(cityAmount, true);
//            int[] cityCost = new int[cityAmount];
//            Stack<int> citiesStack = new Stack<int>();
//            citiesStack.Push(idStart);
//            while (citiesStack.TryPop(out int currentCity))
//            {
//                if (isWeDontBurnThisCity[currentCity])
//                {
//                    for (int i = 0; i < mapData.Length; i++)
//                    {
//                        if (mapData[i][0] == currentCity)
//                        {
//                            if (cityCost[currentCity] + mapData[i][2] > cityCost[mapData[i][1]])
//                                cityCost[mapData[i][1]] = cityCost[currentCity] + mapData[i][2];
//                            if (isWeDontBurnThisCity[mapData[i][1]])
//                            {
//                                citiesStack.Push(mapData[i][1]);
//                            }
//                        }                        
//                    }
//                    isWeDontBurnThisCity[currentCity] = false;
//                }
//            }
//            //код алгоритма
//            if (cityCost[idFinish] == 0) return -1;
//            return cityCost[idFinish];
//        }

//        /// Тестирующая система, лучше не трогать этот код
       
//        private static void TestGenerateWordsFromWord()
//        {
//            var wordsList = new List<string>
//            {
//                "кот", "ток", "око", "мимо", "гром", "ром", "мама",
//                "рог", "морг", "огр", "мор", "порог", "бра", "раб", "зубр"
//            };

//            AssertSequenceEqual(GenerateWordsFromWord("арбуз", wordsList), new[] { "бра", "зубр", "раб" });
//            AssertSequenceEqual(GenerateWordsFromWord("лист", wordsList), new List<string>());
//            AssertSequenceEqual(GenerateWordsFromWord("маг", wordsList), new List<string>());
//            AssertSequenceEqual(GenerateWordsFromWord("погром", wordsList), new List<string> { "гром", "мор", "морг", "огр", "порог", "рог", "ром" });
//        }

//        private static void TestMaxLengthTwoChar()
//        {
//            AssertEqual(MaxLengthTwoChar("beabeeab"), 5);
//            AssertEqual(MaxLengthTwoChar("а"), 0);
//            AssertEqual(MaxLengthTwoChar("ab"), 2);
//        }

//        private static void TestGetPreviousMaxDigital()
//        {
//            AssertEqual(GetPreviousMaxDigital(21), 12l);
//            AssertEqual(GetPreviousMaxDigital(531), 513l);
//            AssertEqual(GetPreviousMaxDigital(1027), -1l);
//            AssertEqual(GetPreviousMaxDigital(2071), 2017l);
//            AssertEqual(GetPreviousMaxDigital(207034), 204730l);
//            AssertEqual(GetPreviousMaxDigital(135), -1l);
//        }

//        private static void TestSearchQueenOrHorse()
//        {
//            char[][] gridA =
//            {
//                new[] {'s', '#', '#', '#', '#', '#'},
//                new[] {'#', 'x', 'x', 'x', 'x', '#'},
//                new[] {'#', '#', '#', '#', 'x', '#'},
//                new[] {'#', '#', '#', '#', 'x', '#'},
//                new[] {'#', '#', '#', '#', '#', 'e'},
//            };

//            AssertSequenceEqual(SearchQueenOrHorse(gridA), new[] { 3, 2 });

//            char[][] gridB =
//            {
//                new[] {'s', '#', '#', '#', '#', 'x'},
//                new[] {'#', 'x', 'x', 'x', 'x', '#'},
//                new[] {'#', 'x', '#', '#', 'x', '#'},
//                new[] {'#', '#', '#', '#', 'x', '#'},
//                new[] {'x', '#', '#', '#', '#', 'e'},
//            };

//            AssertSequenceEqual(SearchQueenOrHorse(gridB), new[] { -1, 3 });

//            char[][] gridC =
//            {
//                new[] {'s', '#', '#', '#', '#', 'x'},
//                new[] {'x', 'x', 'x', 'x', 'x', 'x'},
//                new[] {'#', '#', '#', '#', 'x', '#'},
//                new[] {'#', '#', '#', 'e', 'x', '#'},
//                new[] {'x', '#', '#', '#', '#', '#'},
//            };

//            AssertSequenceEqual(SearchQueenOrHorse(gridC), new[] { 2, -1 });


//            char[][] gridD =
//            {
//                new[] {'e', '#'},
//                new[] {'x', 's'},
//            };

//            AssertSequenceEqual(SearchQueenOrHorse(gridD), new[] { -1, 1 });

//            char[][] gridE =
//            {
//                new[] {'e', '#'},
//                new[] {'x', 'x'},
//                new[] {'#', 's'},
//            };

//            AssertSequenceEqual(SearchQueenOrHorse(gridE), new[] { 1, -1 });

//            char[][] gridF =
//            {
//                new[] {'x', '#', '#', 'x'},
//                new[] {'#', 'x', 'x', '#'},
//                new[] {'#', 'x', '#', 'x'},
//                new[] {'e', 'x', 'x', 's'},
//                new[] {'#', 'x', 'x', '#'},
//                new[] {'x', '#', '#', 'x'},
//            };

//            AssertSequenceEqual(SearchQueenOrHorse(gridF), new[] { -1, 5 });
//        }

//        private static void TestCalculateMaxCoins()
//        {
//            var mapA = new[]
//            {
//                new []{0, 1, 1},
//                new []{0, 2, 4},
//                new []{0, 3, 3},
//                new []{1, 3, 10},
//                new []{2, 3, 6},
//            };

//            AssertEqual(CalculateMaxCoins(mapA, 0, 3), 11l);

//            var mapB = new[]
//            {
//                new []{0, 1, 1},
//                new []{1, 2, 53},
//                new []{2, 3, 5},
//                new []{5, 4, 10}
//            };

//            AssertEqual(CalculateMaxCoins(mapB, 0, 5), -1l);

//            var mapC = new[]
//            {
//                new []{0, 1, 1},
//                new []{0, 3, 2},
//                new []{0, 5, 10},
//                new []{1, 2, 3},
//                new []{2, 3, 2},
//                new []{2, 4, 7},
//                new []{3, 5, 3},
//                new []{4, 5, 8}
//            };

//            AssertEqual(CalculateMaxCoins(mapC, 0, 5), 19l);
//        }
              
//        private static void Assert(bool value)
//        {
//            if (value)
//            {
//                return;
//            }

//            throw new Exception("Assertion failed");
//        }

//        private static void AssertEqual(object value, object expectedValue)
//        {
//            if (value.Equals(expectedValue))
//            {
//                return;
//            }

//            throw new Exception($"Assertion failed expected = {expectedValue} actual = {value}");
//        }

//        private static void AssertSequenceEqual<T>(IEnumerable<T> value, IEnumerable<T> expectedValue)
//        {
//            if (ReferenceEquals(value, expectedValue))
//            {
//                return;
//            }

//            if (value is null)
//            {
//                throw new ArgumentNullException(nameof(value));
//            }

//            if (expectedValue is null)
//            {
//                throw new ArgumentNullException(nameof(expectedValue));
//            }

//            var valueList = value.ToList();
//            var expectedValueList = expectedValue.ToList();

//            if (valueList.Count != expectedValueList.Count)
//            {
//                throw new Exception($"Assertion failed expected count = {expectedValueList.Count} actual count = {valueList.Count}");
//            }

//            for (var i = 0; i < valueList.Count; i++)
//            {
//                if (!valueList[i].Equals(expectedValueList[i]))
//                {
//                    throw new Exception($"Assertion failed expected value at {i} = {expectedValueList[i]} actual = {valueList[i]}");
//                }
//            }
//        }
//    }

//}