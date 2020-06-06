namespace GA.LAED.Airbnb.Search
{
    public class AirbnbBinary
    {
        #region [ Properties ]

        /// <summary>
        /// Array ordenado de Airbnb
        /// </summary>
        /// <value>Array de Airbnb</value>
        private Airbnb[] OrderedArray { get; set; }

        #endregion

        #region [ Constructor ]

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="array">Array base para montagem</param>
        public AirbnbBinary(Airbnb[] array)
        {
            this.OrderedArray = this.GetCopy(array);
            this.Sort();
        }

        #endregion

        #region [ Search ]

        /// <summary>
        /// Realiza a busca binária
        /// </summary>
        /// <param name="idRoom">Id Room</param>
        /// <param name="comparisons">Total de comparações</param>
        /// <returns>Objeto Airbnb</returns>
        public Airbnb Search(int idRoom, out int comparisons)
        {
            comparisons = 0;

            return null;
        }

        #endregion

        #region [ Sort ]

        /// <summary>
        /// Ordena o array utilizando o Selection Sort
        /// </summary>
        private void Sort()
        {
            if (this.OrderedArray == null) return;

            int min, aux;
            for (int i = 0; i < this.OrderedArray.Length - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < this.OrderedArray.Length; j++)
                {
                    if (this.OrderedArray[j].RoomId < this.OrderedArray[min].RoomId)
                    {
                        min = j;
                    }
                }
                if (min != i)
                {
                    aux = this.OrderedArray[min].RoomId;
                    this.OrderedArray[min].RoomId = this.OrderedArray[i].RoomId;
                    this.OrderedArray[i].RoomId = aux;
                }
            }
        }

        #endregion

        #region [ Copy ]

        /// <summary>
        /// Copia os valores de um array para um novo array
        /// </summary>
        /// <param name="array">Array externo</param>
        /// <returns>Cópia</returns>
        private Airbnb[] GetCopy(Airbnb[] array)
        {
            Airbnb[] airbnbCopy = new Airbnb[array.Length];

            for (int i = 0; i < airbnbCopy.Length; i++)
            {
                airbnbCopy[i] = array[i].GetCopy();
            }

            return airbnbCopy;
        }

        #endregion
    }
}