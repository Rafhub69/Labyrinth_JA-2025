#pragma once

#include <vector>
#include <utility>
#include <algorithm>

enum Roles
{
    Empty,
    Wall,
    Begining,
    End,
    Path
};

class Cell
{
private:
    int distanceFromStart = -1;
    int distanceFromEnd = -1;
    int totalDistance = -1;

    std::pair<int, int> cord;
    std::pair<int, int> parent;
    std::vector<std::pair<int, int>> neighbors = { {-1, -1}, {-1, -1}, {-1, -1}, {-1, -1} };
    enum Roles state;// true - Wall, false - Empty

public:
    Cell(int newCordX, int newCordY, Roles newState);

    int getCordX();
    void setCordX(int newCordX);

    int getCordY();
    void setCordY(int newCordY);

    Roles getState();
    void setState(Roles newState);

    int getDistanceFromStart();
    void setDistanceFromStart(int newDistanceFromStart);

    int getDistanceFromEnd();
    void setDistanceFromEnd(int newDistanceFromEnd);

    int getTotalDistance();
    void setTotalDistance(int newTotalDistance);

    std::pair<int, int> getParent();
    void setParent(std::pair<int, int> newParent);

    std::vector<std::pair<int, int>> getNeighbors();
    void setNeighbors(std::vector<std::pair<int, int>> newParent);

    std::pair<int, int> getNeighbor(int index);
    void setNeighbor(std::pair<int, int> newParent, int index);
};

