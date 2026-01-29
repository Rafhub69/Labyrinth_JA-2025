#include "pch.h"
#include "Cell.h"

Cell::Cell(int newCordX, int newCordY, Roles newState)
{
    this->cord.first = newCordX;
    this->cord.second = newCordY;
    this->state = newState;

    this->parent.first = -1;
    this->parent.second = -1;
}

int Cell::getCordX()
{
    return this->cord.first;
}

void Cell::setCordX(int newCordX)
{
    this->cord.first = newCordX;
}

int Cell::getCordY()
{
    return this->cord.second;
}

void Cell::setCordY(int newCordY)
{
    this->cord.second = newCordY;
}

Roles Cell::getState()
{
    return this->state;
}

void Cell::setState(Roles newState)
{
    this->state = newState;
}

int Cell::getDistanceFromStart()
{
    return this->distanceFromStart;
}

void Cell::setDistanceFromStart(int newDistanceFromStart)
{
    this->distanceFromStart = newDistanceFromStart;
}

int Cell::getDistanceFromEnd()
{
    return this->distanceFromEnd;
}

void Cell::setDistanceFromEnd(int newDistanceFromEnd)
{
    this->distanceFromEnd = newDistanceFromEnd;
}

int Cell::getTotalDistance()
{
    return this->totalDistance;
}

void Cell::setTotalDistance(int newTotalDistance)
{
    this->totalDistance = newTotalDistance;
}

std::pair<int, int> Cell::getParent()
{
    return this->parent;
}

void Cell::setParent(std::pair<int, int> newParent)
{
    this->parent = newParent;
}

std::vector<std::pair<int, int>> Cell::getNeighbors()
{
    return this->neighbors;
}

void Cell::setNeighbors(std::vector<std::pair<int, int>> newNeighbors)
{
    this->neighbors = newNeighbors;
}

std::pair<int, int> Cell::getNeighbor(int index)
{
    return this->neighbors.at(index);
}

void Cell::setNeighbor(std::pair<int, int> newNeighbor, int index)
{
    this->neighbors.at(index) = newNeighbor;
}