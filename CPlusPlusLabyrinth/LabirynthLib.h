#pragma once
#include "Labyrinth.h"
#include <oaidl.h>

#define API __declspec(dllexport)

extern "C" {
	API Labyrinth* CreateLabyrinth(int newLength, int newHeight, int newStartX, int newStartY, int newEndX, int newEndY);
	API void DisposeLabyrinth(Labyrinth* lab);
	API void createLabyrinthInC(Labyrinth* lab, int* array, int arraySize);
	API void solveLabyrinthInC(Labyrinth* lab, int* array, int arraySize);
}
