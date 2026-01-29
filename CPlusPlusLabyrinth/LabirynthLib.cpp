#include "LabirynthLib.h"


Labyrinth* CreateLabyrinth(int newLength, int newHeight, int newStartX, int newStartY, int newEndX, int newEndY) {
	return new Labyrinth(newLength, newHeight, newStartX, newStartY, newEndX, newEndY);
}

void DisposeLabyrinth(Labyrinth* lab) {
	delete lab;
}

void createLabyrinthInC(Labyrinth* lab, int* array, int arraySize) 
{
	lab->createLabyrinth();

	for (int i = 0; i< arraySize; i++)
	{
		array[i] = lab->getState(i);
	}
}

void solveLabyrinthInC(Labyrinth* lab, int* array, int arraySize) {
	lab->solveLabyrinth();

	for (int i = 0; i < arraySize; i++)
	{
		array[i] = lab->getState(i);
	}
}

