#include "pch.h"
#include "Labyrinth.h"

Labyrinth::Labyrinth(int newLength, int newHeight, int newStartX, int newStartY, int newEndX, int newEndY)
{
	this->length = newLength;
	this->height = newHeight;
	enum Roles newBool = Wall;

	for (int i = 0; i < height; i++)
	{
		for (int j = 0; j < length; j++)
		{
			newBool = Wall;

			labyrinth.push_back(Cell(j, i, newBool));
			SetNeighbors(j, i);
		}
	}

	start = { newStartX, newStartY };
	end = { newEndX, newEndY };

	ChangeCellRole(start, Begining);
	ChangeCellRole(end, End);
}

int Labyrinth::getState(int item)
{
	return labyrinth.at(item).getState();
}

void Labyrinth::printLabyrinth()
{
	/*for (int i = 0; i < labyrinth.size(); i++)
	{
		std::cout << "CordX: " << labyrinth.at(i).getCordX() << " cordY: " << labyrinth.at(i).getCordY() << " state: " << labyrinth.at(i).getState() << "\n";
	}*/

	for (int i = 0; i < height; i++)
	{
		for (int j = 0; j < length; j++)
		{
			if (labyrinth.at(j + length * i).getState() == Empty)
			{
				std::cout << "  ";
			}
			else if (labyrinth.at(j + length * i).getState() == Wall)
			{
				std::cout << " X";
			}
			else if (labyrinth.at(j + length * i).getState() == Begining)
			{
				std::cout << " B";
			}
			else if (labyrinth.at(j + length * i).getState() == End)
			{
				std::cout << " E";
			}
			else if (labyrinth.at(j + length * i).getState() == Path)
			{
				std::cout << " P";
			}
		}

		std::cout << "\n";
	}

	std::cout << "\n";
}

void Labyrinth::SetNeighbors(int x, int y)
{
	int index = x + length * y;

	if (index < 0 || index > labyrinth.size())
	{
		return;
	}

	//left
	if (x > 0)
	{
		labyrinth[index].setNeighbor(std::pair<int, int>(x - 1, y), 0);
	}
	//right
	if (x < length - 1)
	{
		labyrinth[index].setNeighbor(std::pair<int, int>(x + 1, y), 1);
	}
	//top
	if (y > 0)
	{
		labyrinth[index].setNeighbor(std::pair<int, int>(x, y - 1), 2);
	}
	//bottom
	if (y < height - 1)
	{
		labyrinth[index].setNeighbor(std::pair<int, int>(x, y + 1), 3);
	}
}

bool Labyrinth::CheckIfInside(int x, int y)
{
	if (x > -1 && x < length && y > -1 && y < height)
	{
		return true;
	}

	return false;
}

void Labyrinth::ChangeCellsRole(std::vector<std::pair<int, int>> adjacentCells, Roles newState)
{
	for (std::pair<int, int> adjacentCell : adjacentCells)
	{
		ChangeCellRole(adjacentCell, newState);
	}
}

void Labyrinth::ChangeCellRole(std::pair<int, int> adjacentCell, Roles newState)
{
	if (CheckIfInside(adjacentCell.first, adjacentCell.second))
	{
		labyrinth[adjacentCell.first + length * adjacentCell.second].setState(newState);
	}
}

std::vector<std::pair<int, int>> Labyrinth::SetListFrontiers(int x, int y, Roles cellRole)
{
	std::vector<std::pair<int, int>> tab;

	std::pair<int, int> north = { DIRECTIONS[0].first + x, DIRECTIONS[0].second + y };
	std::pair<int, int> south = { DIRECTIONS[1].first + x, DIRECTIONS[1].second + y };
	std::pair<int, int> east = { DIRECTIONS[2].first + x, DIRECTIONS[2].second + y };
	std::pair<int, int> west = { DIRECTIONS[3].first + x, DIRECTIONS[3].second + y };

	if (CheckIfInside(west.first, west.second))
	{
		//left
		if (labyrinth[west.first + length * west.second].getState() == cellRole)
		{
			tab.push_back(west);
		}
	}

	if (CheckIfInside(east.first, east.second))
	{
		//right
		if (labyrinth[east.first + length * east.second].getState() == cellRole)
		{
			tab.push_back(east);
		}
	}

	if (CheckIfInside(north.first, north.second))
	{
		//top
		if (labyrinth[north.first + length * north.second].getState() == cellRole)
		{
			tab.push_back(north);
		}
	}

	if (CheckIfInside(south.first, south.second))
	{
		//bottom
		if (labyrinth[south.first + length * south.second].getState() == cellRole)
		{
			tab.push_back(south);
		}
	}

	return tab;
}

void Labyrinth::SetParent(std::pair<int, int> currentCell, std::pair<int, int> newParent)
{
	std::pair<int, int> error(-1, -1);

	if (currentCell.first == error.first && currentCell.second == error.second)
	{
		return;
	}

	labyrinth[currentCell.first + length * currentCell.second].setParent(newParent);
}

void Labyrinth::CarvePath(std::pair<int, int> start, std::pair<int, int> end, Roles cellRole)
{

	std::pair<int, int> check = start;
	std::pair<int, int> between(-1, -1);

	for (int i = 0; i < 4; i++)
	{
		check = start;

		check.first += DIRECTIONS[i].first;
		check.second += DIRECTIONS[i].second;

		if (check.first == end.first && check.second == end.second)
		{
			between.first = start.first + (DIRECTIONS[i].first / 2);
			between.second = start.second + (DIRECTIONS[i].second / 2);

			labyrinth[start.first + length * start.second].setState(cellRole);
			labyrinth[between.first + length * between.second].setState(cellRole);
			labyrinth[end.first + length * end.second].setState(cellRole);

			return;
		}
	}
}

void Labyrinth::createLabyrinth()
{
	int randomIndex = 0;
	std::random_device rd;
	std::mt19937 gen(rd());
	std::uniform_int_distribution<>distrib(0, 1);

	std::vector<std::pair<int, int>> frontierCells;
	std::vector<std::pair<int, int>> adjacentCells;
	std::pair<int, int> currentElement = start;
	int maxNumberOfCells = length * height;

	adjacentCells = SetListFrontiers(currentElement.first, currentElement.second, Wall);

	ChangeCellsRole(adjacentCells, Empty);

	for (int i = 0; i < adjacentCells.size(); i++)
	{
		SetParent(adjacentCells.at(i), currentElement);
	}

	frontierCells.insert(frontierCells.end(), adjacentCells.begin(), adjacentCells.end());

	while (frontierCells.size() < maxNumberOfCells * 2 && frontierCells.size() > 0)
	{
		distrib = std::uniform_int_distribution<int>(0, frontierCells.size() - 1);
		randomIndex = distrib(gen);

		currentElement = frontierCells.at(randomIndex);

		adjacentCells = SetListFrontiers(currentElement.first, currentElement.second, Wall);

		ChangeCellsRole(adjacentCells, Empty);

		CarvePath(labyrinth[currentElement.first + length * currentElement.second].getParent(), currentElement, Empty);

		for (int i = 0; i < adjacentCells.size(); i++)
		{
			SetParent(adjacentCells.at(i), currentElement);
		}

		frontierCells.insert(frontierCells.end(), adjacentCells.begin(), adjacentCells.end());

		frontierCells.erase(frontierCells.begin() + randomIndex);
	}

	ChangeCellRole(start, Begining);
	ChangeCellRole(end, End);
}

std::vector<std::pair<int, int>> Labyrinth::GetNeighbors(std::pair<int, int> cord)
{
	std::vector<std::pair<int, int>>tab;

	if (cord.first < 0 || cord.second < 0 || cord.first > length || cord.second > height)
	{
		std::pair<int, int> error(-1, -1);

		for (int i = 0; i < 4; i++)
		{
			tab.push_back(error);
		}

		return tab;
	}

	return tab;
}

int Labyrinth::GetHeuristics(std::pair<int, int> start, std::pair<int, int> end)
{
	int newHeuristic = length * height;

	std::pair<int, int> error(-1, -1);

	if (start.first == error.first && start.second == error.second || end.first == error.first && end.second == error.second)
	{
		return newHeuristic;
	}

	newHeuristic = std::abs(end.second - start.second) + std::abs(end.first - start.first);

	labyrinth[start.first + length * start.second].setDistanceFromEnd(newHeuristic);

	if (maxDistanceFromEnd < newHeuristic)
	{
		maxDistanceFromEnd = newHeuristic;
	}

	return newHeuristic;
}

void Labyrinth::SetTotalDistance(std::pair<int, int> cord)
{
	int index = cord.first + length * cord.second;

	labyrinth[index].setTotalDistance(labyrinth[index].getDistanceFromEnd() + labyrinth[index].getDistanceFromStart());
}

void Labyrinth::SetDistanceFromEnd(std::pair<int, int> cord, int dist)
{
	labyrinth[cord.first + length * cord.second].setDistanceFromStart(dist);
}

void Labyrinth::SetDistanceFromStart(std::pair<int, int> cord, int dist)
{
	if (maxDistanceFromEnd < dist)
	{
		maxDistanceFromEnd = dist;
	}

	labyrinth[cord.first + length * cord.second].setDistanceFromEnd(dist);
}

void Labyrinth::solveLabyrinth()
{
	int currentPointIndex = 0;
	int openNodeIndex = 0;

	bool isSame = true;
	bool isCurrentH = true;
	bool isCurrentDistance = true;
	std::pair<int, int> error = { -1, -1 };
	std::pair<int, int> currentPoint = { -1, -1 };

	std::vector<std::pair<int, int>> openNodes;
	std::vector<std::pair<int, int>> closedNodes;

	int newMovCostItem = 0, index = 0;

	openNodes.push_back(start);

	while (openNodes.size() > 0)
	{
		currentPoint = openNodes.at(0);
		for (int i = 1; i < openNodes.size(); i++)
		{
			currentPointIndex = currentPoint.first + length * currentPoint.second;
			openNodeIndex = openNodes[i].first + length * openNodes[i].second;

			isCurrentDistance = labyrinth[openNodeIndex].getTotalDistance() < labyrinth[currentPointIndex].getTotalDistance();
			isCurrentH = labyrinth[openNodeIndex].getDistanceFromEnd() < labyrinth[currentPointIndex].getDistanceFromEnd();
			isSame = labyrinth[openNodeIndex].getTotalDistance() == labyrinth[currentPointIndex].getTotalDistance();

			if (isCurrentDistance || isSame && isCurrentH)
			{
				currentPoint = openNodes[i];
				index = i;
			}
		}

		openNodes.erase(openNodes.begin() + index);
		closedNodes.push_back(currentPoint);

		if (currentPoint.first == end.first && currentPoint.second == end.second)
		{
			bool isStartFound = false;
			std::pair<int, int> currentCell = end;
			std::pair<int, int> nextCell = labyrinth[currentCell.first + length * currentCell.second].getParent();

			while (!isStartFound)
			{
				currentCell = nextCell;
				nextCell = labyrinth[currentCell.first + length * currentCell.second].getParent();
				ChangeCellRole(currentCell, Path);

				if (nextCell == start)
				{
					isStartFound = true;
				}
			}

			ChangeCellRole(start, Begining);
			ChangeCellRole(end, End);

			return;
		}

		for (std::pair<int, int> item : GetNeighbors(currentPoint))
		{
			if (item.first == error.first && item.second == error.second)
			{
				continue;
			}

			if (labyrinth[item.first + length * item.second].getState() == Wall || std::find(closedNodes.begin(), closedNodes.end(), item) != closedNodes.end())
			{
				continue;
			}

			newMovCostItem = labyrinth[currentPoint.first + length * currentPoint.second].getDistanceFromStart() + GetHeuristics(currentPoint, item);

			if (newMovCostItem < labyrinth[item.first + length * item.second].getDistanceFromStart() || std::find(openNodes.begin(), openNodes.end(), item) == openNodes.end())
			{
				SetDistanceFromEnd(item, GetHeuristics(item, end));
				SetDistanceFromStart(item, newMovCostItem);
				SetParent(item, currentPoint);
				SetTotalDistance(item);


				if (std::find(openNodes.begin(), openNodes.end(), item) == closedNodes.end())
				{
					openNodes.push_back(item);
				}
			}
		}

		closedNodes.push_back(currentPoint);
	}

}

std::pair<int, int> Labyrinth::getStart()
{
	return start;
}

void Labyrinth::setStart(std::pair<int, int> newStart)
{
	start = newStart;
}

std::pair<int, int> Labyrinth::getEnd()
{
	return end;
}

void Labyrinth::setEnd(std::pair<int, int> newEnd)
{
	end = newEnd;
}