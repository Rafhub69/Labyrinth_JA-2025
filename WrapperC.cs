using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace finalProjectJA_2025
{
    internal class WrapperC : IDisposable
    {
        private const string COUNTER_LIB_DLL_PATH = "CPlusPlusLabyrinth.dll";

        [DllImport(COUNTER_LIB_DLL_PATH, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr CreateLabyrinth(int newLenght, int newHeight);

        [DllImport(COUNTER_LIB_DLL_PATH, CallingConvention = CallingConvention.Cdecl)]
        private static extern void DisposeLabyrinth(IntPtr counterPointer);

        [DllImport(COUNTER_LIB_DLL_PATH, CallingConvention = CallingConvention.Cdecl)]
        private static extern void createLabyrinthInC(IntPtr counterPointer);

        [DllImport(COUNTER_LIB_DLL_PATH, CallingConvention = CallingConvention.Cdecl)]
        private static extern void solveLabyrinth(IntPtr counterPointer);

        private IntPtr counterPointer;

        public WrapperC(int newLenght, int newHeight)
        {
            counterPointer = CreateLabyrinth(newLenght, newHeight);

            if (counterPointer == IntPtr.Zero)
            {
                throw new InvalidOperationException("Failed to create counter.");
            }
        }

        public void createLabyrinthWrapper()
        {
            createLabyrinthInC(counterPointer);
        }
        public void solveLabyrinthWrapper()
        {
            solveLabyrinth(counterPointer);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
