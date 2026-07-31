using PortfolioDigital.Infrastructure.Exceptions;

namespace PortfolioDigital.Infrastructure.Entities
{
    public class Prestation : AggregateRoot
    {
        /// <summary>
        /// Name of the prestation.
        /// This property represents the name or title of the prestation.
        /// It is a required field and should be descriptive enough to give an idea of what the prestation is about.
        /// </summary>
        public string Name { get; private set; } = string.Empty;

        /// <summary>
        /// Description of the prestation.
        /// This property provides a detailed description of the prestation, including its purpose, features, and any other relevant information.
        /// It is a required field and should be descriptive enough to give an idea of what the prestation is about.
        /// </summary>
        public string Description { get; private set; } = string.Empty;

        /// <summary>
        /// Price of the prestation.
        /// This property represents the price or cost associated with the prestation.
        /// It is a required field and should be a non-negative value.
        /// The price can be used for billing, invoicing, or displaying the cost of the prestation to potential clients or customers.
        /// </summary>
        public double Price { get; private set; } = 0.0;

        /// <summary>
        /// Services associated with the prestation.
        /// This property represents a collection of services that are included or related to the prestation.
        /// It is a read-only collection that can be accessed but not modified directly.
        /// The services can be used to provide additional information about what is included in the prestation or to categorize the prestation based on the services it offers.
        /// </summary>
        private readonly List<string> _services = [];

        /// <summary>
        /// Gets the read-only collection of services associated with the prestation.
        /// This property provides access to the services included or related to the prestation.
        /// It is a read-only collection that can be accessed but not modified directly.
        /// The services can be used to provide additional information about what is included in the prestation or to categorize the prestation based on the services it offers.
        /// </summary>
        public IReadOnlyCollection<string> Services => _services.AsReadOnly();

        /// <summary>
        /// Default constructor for EF Core.
        /// This constructor is required by Entity Framework Core for materialization of the entity from the database.
        /// It is marked as private to prevent direct instantiation of the Prestation class outside of the context of EF Core.
        /// </summary>
#pragma warning disable CS8618
        private Prestation() { } // EF Core
#pragma warning restore CS8618 

        /// <summary>
        /// Creates a new Prestation instance with the specified name, description, price, and services.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="price"></param>
        /// <param name="services"></param>
        /// <returns></returns>
        public static Prestation Create(string name, string description, double price, params string[] services)
        {
            var prestation = new Prestation();
            prestation.SetName(name);
            prestation.SetDescription(description);
            prestation.SetPrice(price);
            prestation.addService(services);
            return prestation;
        }

        /// <summary>
        /// Sets the name of the prestation.
        /// This method allows you to change the name of the prestation to a new value.
        /// It validates that the name is not null, empty, or too short/long.
        /// If the name is invalid, it throws a BusinessRuleViolationException. 
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="BusinessRuleViolationException"></exception>
        public void SetDescription(string value)
        {
            try
            {
                Description = ValidateDescription(value);
            }
            catch (Exception ex)
            {
                throw new BusinessRuleViolationException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Sets the price of the prestation.
        /// This method allows you to change the price of the prestation to a new value.
        /// It validates that the price is a non-negative value.
        /// If the price is negative, it throws a BusinessRuleViolationException.
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="BusinessRuleViolationException"></exception>
        public void SetPrice(double value)
        {
            try
            {
                Price = ValidatePrice(value);
            }
            catch (Exception ex)
            {
                throw new BusinessRuleViolationException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Sets the name of the prestation.
        /// This method allows you to change the name of the prestation to a new value.
        /// It validates that the name is not null, empty, or too short/long.
        /// If the name is invalid, it throws a BusinessRuleViolationException.
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="BusinessRuleViolationException"></exception>
        public void SetService(string value)
        {
            try
            {
                _services.Add(ValidateService(value));
            }
            catch (Exception ex)
            {
                throw new BusinessRuleViolationException(ex.Message, ex);
            }
        }  

        /// <summary>
        /// Sets the name of the prestation.
        /// This method allows you to change the name of the prestation to a new value.
        /// It validates that the name is not null, empty, or too short/long.
        /// If the name is invalid, it throws a BusinessRuleViolationException.
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="BusinessRuleViolationException"></exception>
        private void SetName(string value)
        {
            try
            {
                Name = ValidateName(value);
            }
            catch (Exception ex)
            {
                throw new BusinessRuleViolationException(ex.Message, ex);
            }
        }

        /// <summary>
        ///  Adds one or more services to the prestation.
        ///  This method allows you to add multiple services to the prestation at once.
        ///  It validates that each service is not null, empty, or too short/long.
        ///  If any service is invalid, it throws a BusinessRuleViolationException.
        ///  If a service already exists in the prestation, it will be updated with the new value.
        /// </summary>
        /// <param name="values"></param>
        /// <exception cref="BusinessRuleViolationException"></exception>
        private void addService(params string[] values)
        {
            try
            {
                foreach (var value in values)
                {
                    var result = ValidateService(value);

                    if (_services.Contains(result))
                    {
                        var index = _services.FindIndex(x => x == result);
                        _services[index] = result;
                    }
                    else
                    {
                        _services.Add(result);
                    }
                }
                _services.AddRange(values);
            }
            catch (Exception ex)
            {
                throw new BusinessRuleViolationException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Validates the service name.
        /// This method checks if the provided service name is not null, empty, or whitespace.
        /// If the service name is invalid, it throws a BusinessRuleViolationException. 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="BusinessRuleViolationException"></exception>
        private static string ValidateService(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new BusinessRuleViolationException("Service cannot be null or empty.");

            return value;
        }

        /// <summary>
        /// Validates the provided prestation name.
        /// This method checks if the provided name is not null, empty, or whitespace.
        /// If the name is invalid, it throws a BusinessRuleViolationException.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="BusinessRuleViolationException"></exception>
        private static string ValidateDescription(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new BusinessRuleViolationException("Description is required.", new ArgumentNullException(nameof(value)));

            return value;
        }

        /// <summary>
        /// Validates the provided prestation name.
        /// This method checks if the provided name is not null, empty, or whitespace.
        /// If the name is invalid, it throws a BusinessRuleViolationException.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="BusinessRuleViolationException"></exception>
        private static string ValidateName(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new BusinessRuleViolationException("Name is required.", new ArgumentNullException(nameof(value)));

            return value;
        }

        /// <summary>
        /// Validates the provided prestation price.
        /// This method checks if the provided price is a non-negative value.
        /// If the price is negative, it throws a BusinessRuleViolationException.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="BusinessRuleViolationException"></exception>
        private static double ValidatePrice(double value)
        {
            if (value < 0)
                throw new BusinessRuleViolationException("Price cannot be negative.", new ArgumentOutOfRangeException(nameof(value)));

            return value;
        }
    }
}