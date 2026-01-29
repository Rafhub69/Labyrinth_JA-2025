#pragma once

#include <cmath>
#include <random>
#include <iostream>
#include "Cell.h"

class Labyrinth
{
private:
	int maxDistanceFromEnd = 0;
	std::vector<Cell> labyrinth;
	std::pair<int, int> start;
	std::pair<int, int> end;
	int length;
	int height;

	std::pair<int, int> DIRECTIONS[4] = {
		{0 ,-2}, // north
		{0 , 2}, // south
		{2 , 0}, // east
		{-2, 0} // west
	};


public:
	Labyrinth(int newLength, int newHeight, int newStartX, int newStartY, int newEndX, int newEndY);
	void printLabyrinth();

	std::pair<int, int> getStart();
	void setStart(std::pair<int, int> newStart);

	std::pair<int, int> getEnd();
	void setEnd(std::pair<int, int> newEnd);

	int GetDistanceFromEnd();
	void createLabyrinth();
	void solveLabyrinth();

	std::vector<std::pair<int, int>> SetListFrontiers(int x, int y, Roles cellRole);
	bool CheckIfInside(int x, int y);
	void ChangeCellsRole(std::vector<std::pair<int, int>> adjacentCells, Roles isState);
	void ChangeCellRole(std::pair<int, int> adjacentCell, Roles isState);
	void SetParent(std::pair<int, int> currentCell, std::pair<int, int> newParent);

	void CarvePath(std::pair<int, int> start, std::pair<int, int> end, Roles cellRole);

	std::vector<std::pair<int, int>> GetNeighbors(std::pair<int, int> point);
	void SetNeighbors(int x, int y);

	int GetHeuristics(std::pair<int, int> start, std::pair<int, int> end);

	void SetDistanceFromEnd(std::pair<int, int> cord, int dist);
	void SetDistanceFromStart(std::pair<int, int> cord, int dist);
	void SetTotalDistance(std::pair<int, int> item);

	int getState(int item);
};

