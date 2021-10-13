using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LE_Craft_Calculator
{
	class CraftCalculations
	{
		public CraftingPoint Calculating(int instability, int[] startAffixes, int[] endAffixes,bool usingGuardianGlyph)//возвратить итоговое решение вместо void
        {
			Console.WriteLine("Starting");
			int numberOfSteps = CalcNumberOfSteps(startAffixes, endAffixes);
			Console.WriteLine("number of steps="+numberOfSteps);
			List<CraftingPoint>[] graphPoints = new List<CraftingPoint>[numberOfSteps + 1];
			for(int i=0;i<=numberOfSteps;i++)
            {
				graphPoints[i] = new List<CraftingPoint>();
            }
			CraftingPoint initPoint= InitializeFirstPoint(startAffixes);
			graphPoints[0].Add(initPoint);
			//инициализируем граф
			for(int i=1;i<=numberOfSteps;i++)
            {
				graphPoints[i]= AddStep(graphPoints[i - 1], endAffixes);
				Console.WriteLine("Step =" +i+" Step points="+ graphPoints[i].Count);
			}

			//рассчитываем вероятности
			for (int i = 1; i <= numberOfSteps; i++)
            {
				for(int j=0; j<graphPoints[i].Count;j++)
                {
					for (int k=0; k<graphPoints[i][j].craftingPathsIndexes.Count; k++)
                    {
						int tierToCraft=0;
						int affixNumberToCraft = 0;
						//определяем, какой тир крафтим
						for(int m=0; m<endAffixes.Length; m++)
                        {
							if(graphPoints[i][j].affixes[m]!= graphPoints[i-1][graphPoints[i][j].craftingPathsIndexes[k]].affixes[m])
                            {
								tierToCraft = graphPoints[i][j].affixes[m];
								affixNumberToCraft = m;
								//Console.WriteLine("tier to craft is "+tierToCraft);
								break;
							}
                        }

						float newProbability = Probability(instability+(i-1)*5, tierToCraft, usingGuardianGlyph) * graphPoints[i - 1][graphPoints[i][j].craftingPathsIndexes[k]].probability;//берем instability как начальную+current step*5
						if (graphPoints[i][j].probability < newProbability)
						{
							graphPoints[i][j].probability = newProbability;
							graphPoints[i][j].howToCraftResult = graphPoints[i - 1][graphPoints[i][j].craftingPathsIndexes[k]].howToCraftResult + " " + (affixNumberToCraft+1);
						} 

					}
				}
            }
			return graphPoints[numberOfSteps][0];
		}

		private List<CraftingPoint> AddStep(List<CraftingPoint> previousStepPoints, int[] endAffixes)
        {
			List<CraftingPoint> stepPoints = new List<CraftingPoint>();
			//реализуем новые точки
			for (int i=0;i<previousStepPoints.Count;i++)
            {
				for (int k = 0; k < endAffixes.Length; k++)
				{
					if (previousStepPoints[i].affixes[k] < endAffixes[k])//добавляем новую точку в новый шаг
					{
						int n = 0;
						bool pointExist=false;//такая точка уже есть в графе
						int[] newAffixes = new int[endAffixes.Length];
						for (int j = 0; j < endAffixes.Length; j++)
						{
							newAffixes[j] = previousStepPoints[i].affixes[j];
						}
						newAffixes[k] += 1;
						//определяем, есть ли такая точка в графе
						for (int m=0; m<stepPoints.Count;m++)
                        {
							if (newAffixes.SequenceEqual(stepPoints[m].affixes))
                            {
								n = m;
								pointExist = true;
								break;
                            }
                        }
						if (pointExist) //точка с такими аффиксами уже существует. Добавляем связанный путь
                        {
							stepPoints[n].craftingPathsIndexes.Add(i);

                        } else //добавляем точку с увеличенными аффиксами
                        {
							CraftingPoint newPoint = new CraftingPoint();
							newPoint.InitializePoint(endAffixes.Length);
							newPoint.probability = 0;//нулевая вероятность при инициализации для использования алгоритма Дейкстры
							newPoint.affixes = newAffixes;
							newPoint.craftingPathsIndexes.Add(i);
							stepPoints.Add(newPoint);

						}
					}
				}
			}
			return stepPoints;
        }
		private float Probability(float instability, float affixTier, bool usingGuardianGlyph)
		{
			float p;
			if (instability == 0)
			{
				p = 1f;
			}
			else
			{
				p = 1f - 0.01f * (instability + (5f * affixTier - 5f));

				if (usingGuardianGlyph) p += 0.25f;
				if (affixTier == 4) p -= 0.02f;
				if (affixTier == 5) p -= 0.05f;
				
				if (p < 0) p = 0f;
				if (p > 1) p = 1f;//для глифов стабильности
			}
			return p;
		}

		private int CalcNumberOfSteps(int[] startAffixes, int[] endAffixes)
        {
			int numberOfSteps = 0;
			for (int i=0; i<endAffixes.Length; i++)
            {
				for (int k = startAffixes[i]; k < endAffixes[i]; k++)
				{
					numberOfSteps += 1;
				}
			}
			return numberOfSteps;
        }

		private CraftingPoint InitializeFirstPoint(int[] startAffixes)
        {
			CraftingPoint initCraftingPoint= new CraftingPoint();
			initCraftingPoint.InitializePoint(startAffixes.Length);
			for (int n = 0; n < startAffixes.Length; n++)
			{
				initCraftingPoint.affixes[n] = startAffixes[n];
			}
			initCraftingPoint.probability = 1f;
			initCraftingPoint.howToCraftResult = "Crafting steps:";
			return initCraftingPoint;
        }

	}

}