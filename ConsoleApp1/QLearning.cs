using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class QLearning
    {
        private double alpha = 0.1; // Learning rate
        private double gamma = 0.9; // Eagerness - 0 looks in the near future, 1 looks in the distant future

        private int mazeWidth = 3;
        private int mazeHeight = 3;
        private int statesCount;

        private int reward = 100;
        private int penalty = -10;

        private char[,] maze;  // Maze read from file
        private int[,] R;       // Reward lookup
        private double[,] Q;    // Q learning

        public QLearning()
        {
            statesCount = mazeHeight * mazeWidth;
        }

        public void init()
        {
            String[] file = File.ReadAllLines(@"maze.txt");
            String teste = file[0];

            R = new int[statesCount,statesCount];
            Q = new double[statesCount,statesCount];
            maze = new char[mazeHeight,mazeWidth];

            int i = 0;
            int j = 0;

            for (int l = 0; l < teste.Length; l++)
            {
                if (!teste[l].Equals("0") && !teste[l].Equals("F") && !teste[l].Equals("X"))
                    continue;

                maze[i,j] = teste[i];
                j++;
                if (j == mazeWidth)
                {
                    j = 0;
                    i++;
                }
            }

            // We will navigate through the reward matrix R using k index
            for (int k = 0; k < statesCount; k++)
            {

                // We will navigate with i and j through the maze, so we need
                // to translate k into i and j
                i = k / mazeWidth;
                j = k - i * mazeWidth;

                // Fill in the reward matrix with -1
                for (int s = 0; s < statesCount; s++)
                {
                    R[k,s] = -1;
                }

                // If not in final state or a wall try moving in all directions in the maze
                if (maze[i,j] != 'F')
                {

                    // Try to move left in the maze
                    int goLeft = j - 1;
                    if (goLeft >= 0)
                    {
                        int target = i * mazeWidth + goLeft;
                        if (maze[i,goLeft] == '0')
                        {
                            R[k,target] = 0;
                        }
                        else if (maze[i,goLeft] == 'F')
                        {
                            R[k,target] = reward;
                        }
                        else
                        {
                            R[k,target] = penalty;
                        }
                    }

                    // Try to move right in the maze
                    int goRight = j + 1;
                    if (goRight < mazeWidth)
                    {
                        int target = i * mazeWidth + goRight;
                        if (maze[i,goRight] == '0')
                        {
                            R[k,target] = 0;
                        }
                        else if (maze[i,goRight] == 'F')
                        {
                            R[k,target] = reward;
                        }
                        else
                        {
                            R[k,target] = penalty;
                        }
                    }

                    // Try to move up in the maze
                    int goUp = i - 1;
                    if (goUp >= 0)
                    {
                        int target = goUp * mazeWidth + j;
                        if (maze[goUp,j] == '0')
                        {
                            R[k,target] = 0;
                        }
                        else if (maze[goUp,j] == 'F')
                        {
                            R[k,target] = reward;
                        }
                        else
                        {
                            R[k,target] = penalty;
                        }
                    }

                    // Try to move down in the maze
                    int goDown = i + 1;
                    if (goDown < mazeHeight)
                    {
                        int target = goDown * mazeWidth + j;
                        if (maze[goDown,j] == '0')
                        {
                            R[k,target] = 0;
                        }
                        else if (maze[goDown,j] == 'F')
                        {
                            R[k,target] = reward;
                        }
                        else
                        {
                            R[k,target] = penalty;
                        }
                    }
                }
            }

            printR(R);
        }

        private void printR(int[,] matrix)
        {
            Console.Write("States: " + new String(' ', 17));
            for (int i = 0; i <= 8; i++)
            {
                Console.Write(i.ToString().PadLeft(4));
            }
            Console.WriteLine();

            for (int i = 0; i < statesCount; i++)
            {
                Console.Write("Possible states from " + i + " :[");
                for (int j = 0; j < statesCount; j++)
                {
                    Console.Write(matrix[i,j].ToString().PadLeft(4));
                }
                Console.WriteLine("]");
            }
        }

        public void calculateQ()
        {
            Random rand = new Random();

            for (int i = 0; i < 1000; i++)
            { // Train cycles
              // Select random initial state
                int crtState = rand.Next(statesCount);

                while (!isFinalState(crtState))
                {
                    int[] actionsFromCurrentState = possibleActionsFromState(crtState);

                    // Pick a random action from the ones possible
                    int index = rand.Next(actionsFromCurrentState.Length);
                    int nextState = actionsFromCurrentState[index];

                    // Q(state,action)= Q(state,action) + alpha * (R(state,action) + gamma * Max(next state, all actions) - Q(state,action))
                    double q = Q[crtState,nextState];
                    double varMaxQ = maxQ(nextState);
                    int r = R[crtState,nextState];

                    double value = q + alpha * (r + gamma * varMaxQ - q);
                    Q[crtState,nextState] = value;

                    crtState = nextState;
                }
            }
        }

        private bool isFinalState(int state)
        {
            int i = state / mazeWidth;
            int j = state - i * mazeWidth;

            return maze[i,j] == 'F';
        }

        int[] possibleActionsFromState(int state)
        {
            List<Int32> result = new List<Int32>();
            for (int i = 0; i < statesCount; i++)
            {
                if (R[state,i] != -1)
                {
                    result.Add(i);
                }
            }

            return result.stream().mapToInt(i->i).toArray();
        }

        private double maxQ(int nextState)
        {
            int[] actionsFromState = possibleActionsFromState(nextState);
            double maxValue = Double.NegativeInfinity;
            foreach (int nextAction in actionsFromState)
            {
                double value = Q[nextState,nextAction];

                if (value > maxValue)
                    maxValue = value;
            }
            return maxValue;
        }

        public void printPolicy()
        {
            Console.WriteLine("\nPrint policy");
            for (int i = 0; i < statesCount; i++)
            {
                Console.WriteLine("From state " + i + " goto state " + getPolicyFromState(i));
            }
        }

        private int getPolicyFromState(int state)
        {
            int[] actionsFromState = possibleActionsFromState(state);

            double maxValue = Double.MinValue;
            int policyGotoState = state;

            // Pick to move to the state that has the maximum Q value
            foreach (int nextState in actionsFromState)
            {
                double value = Q[state,nextState];

                if (value > maxValue)
                {
                    maxValue = value;
                    policyGotoState = nextState;
                }
            }
            return policyGotoState;
        }

        public void printQ()
        {
            Console.WriteLine("Q matrix");
            for (int i = 0; i < Q.Length; i++)
            {
                Console.WriteLine("From state " + i + ":  ");
                for (int j = 0; j < Q[,].Length; j++)
                {
                    Console.WriteLine(String.Format("{0:0.00}", Q[i,j]) + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
