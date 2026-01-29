using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace finalProjectJA_2025
{
    internal class WrapperC : IDisposable
    {
        private const string COUNTER_LIB_DLL_PATH = "CPlusPlusLabyrinth.dll";

        [DllImport(COUNTER_LIB_DLL_PATH, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr CreateLabyrinth(int newLength, int newHeight, int newStartX, int newStartY, int newEndX, int newEndY);

        [DllImport(COUNTER_LIB_DLL_PATH, CallingConvention = CallingConvention.Cdecl)]
        private static extern void DisposeLabyrinth(IntPtr counterPointer);

        [DllImport(COUNTER_LIB_DLL_PATH, CallingConvention = CallingConvention.Cdecl)]
        private static extern void createLabyrinthInC(IntPtr counterPointer, int[] array, int arraySize);

        [DllImport(COUNTER_LIB_DLL_PATH, CallingConvention = CallingConvention.Cdecl)]
        private static extern void solveLabyrinthInC(IntPtr counterPointer, int[] array, int arraySize);

        private IntPtr counterPointer;

        public WrapperC(int newLength, int newHeight, int newStartX, int newStartY, int newEndX, int newEndY)
        {
            counterPointer = CreateLabyrinth(newLength, newHeight, newStartX, newStartY, newEndX, newEndY);

            if (counterPointer == IntPtr.Zero)
            {
                throw new InvalidOperationException("Failed to create counter.");
            }
        }

        public void createLabyrinthWrapper(int[] array)
        {
            createLabyrinthInC(counterPointer, array, array.Length);
        }

        public void solveLabyrinthWrapper(int[] array)
        {
            solveLabyrinthInC(counterPointer, array, array.Length);
        }

        public void Dispose()
        {
            DisposeLabyrinth(counterPointer);
        }
    }
}
