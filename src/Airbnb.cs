namespace GA.LAED.Airbnb.Search
{
    /// <summary>
    /// Entidade Airbnb
    /// </summary>
    public class Airbnb
    {
        #region [ Properties ]

        public int RoomId { get; set; }
        public int HostId { get; set; }
        public string RoomType { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public double Reviews { get; set; }
        public double OverallSatisfaction { get; set; }
        public double Accommodates { get; set; }
        public double Bedrooms { get; set; }
        public double Price { get; set; }
        public string PropertyType { get; set; }

        #endregion

        #region [ Constructor ]

        public Airbnb(int roomId,
                      int hostId,
                      string roomType,
                      string city,
                      string country,
                      string neighborhood,
                      double review,
                      double overallSatisfaction,
                      double accommodates,
                      double bedrooms,
                      double price,
                      string propertyType)
        {

            this.RoomId = roomId;
            this.HostId = hostId;
            this.RoomType = roomType;
            this.City = city;
            this.Country = country;
            this.Neighborhood = neighborhood;
            this.Reviews = review;
            this.OverallSatisfaction = overallSatisfaction;
            this.Accommodates = accommodates;
            this.Bedrooms = bedrooms;
            this.Price = price;
            this.PropertyType = propertyType;
        }

        #endregion

        #region [ Copy ]

        /// <summary>
        /// Copia dos valores do objeto atual para um novo objeto
        /// </summary>
        /// <returns>Cópia do Airbnb</returns>
        public Airbnb GetCopy()
        {
            return new Airbnb(this.RoomId,
                              this.HostId,
                              this.RoomType,
                              this.City,
                              this.Country,
                              this.Neighborhood,
                              this.Reviews,
                              this.OverallSatisfaction,
                              this.Accommodates,
                              this.Bedrooms,
                              this.Price,
                              this.PropertyType);
        }

        #endregion

        #region [ To String ]

        /// <summary>
        /// ToString sobrescrito
        /// </summary>
        /// <returns>Dados Airbnb</returns>
        public override string ToString()
        {
            string airbnb = string.Empty;
            airbnb += $"Room Id: {this.RoomId}\n";
            airbnb += $"Host Id: {this.HostId}\n";
            airbnb += $"Room Type: {this.RoomType}\n";
            airbnb += $"Country: {this.Country}\n";
            airbnb += $"City: {this.City}\n";
            airbnb += $"Neighborhood: {this.Neighborhood}\n";
            airbnb += $"Reviews: {this.Reviews}\n";
            airbnb += $"Overall Satisfaction: {this.OverallSatisfaction}\n";
            airbnb += $"Accommodates: {this.Accommodates}\n";
            airbnb += $"Bedrooms: {this.Bedrooms}\n";
            airbnb += $"Price: {this.Price}\n";
            airbnb += $"Property Type: {this.PropertyType}\n";
            return airbnb;
        }

        #endregion
    }
}
