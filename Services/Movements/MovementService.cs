using CreditCardManager.Exceptions;
using CreditCardManager.Models.Cards;
using CreditCardManager.Models.Movement;
using CreditCardManager.Models.Payers;
using CreditCardManager.Repositories.Movements;
using CreditCardManager.Services.Cards;
using CreditCardManager.Services.Payers;

namespace CreditCardManager.Services.Movements
{
    public class MovementService : IMovementService
    {
        private readonly IMovementRepository _movementRepository;
        private readonly IPayerService _payerService;
        private readonly ICardService _cardService;

        public MovementService(IMovementRepository movementRepository, IPayerService payerService, ICardService cardService)
        {
            _movementRepository = movementRepository;
            _payerService = payerService;
            _cardService = cardService;
        }

        public async Task<Movement> CreateMovementAsync(MovementRequest request)
        {
            Payer? payer = await getRequestPayer(request);
            Card? card = await getRequestCard(request);

            var movement = new Movement
            {
                Card = card,
                Amount = request.Amount,
                InstallmentsQty = request.InstallmentsQty,
                Date = DateOnly.TryParse(request.Date, out var parsedDate) ? parsedDate : DateOnly.FromDateTime(DateTime.Now),
                Detail = request.Detail ?? string.Empty,
                Payer = payer,
                Observations = request.Observations ?? string.Empty
            };

            return await AddMovementAsync(movement);
        }

        public async Task<Movement> AddMovementAsync(Movement movement)
        {
            await _movementRepository.AddAsync(movement);
            await _movementRepository.SaveAsync();
            return movement;
        }

        public async Task<Movement?> GetMovementByIdAsync(int id)
        {
            return await _movementRepository.GetByIdAsync(id);
        }

        public async Task<List<Movement>> GetAllMovementsAsync()
        {
            return await _movementRepository.GetAllAsync();
        }

        /*---------*/
        private async Task<Payer?> getRequestPayer(MovementRequest request)
        {
            Payer? payer = null;

            if (request.PayerID.HasValue)
            {
                payer = await _payerService.GetPayerByIdAsync(request.PayerID.Value);
                if (!(payer == null)) return payer;

                throw new NotFoundException($"Payer with ID {request.PayerID.Value} not found.");
            }

            if (!string.IsNullOrEmpty(request.PayerName))
            {
                payer = await _payerService.GetPayerByNameAsync(request.PayerName);

                if (!(payer == null)) return payer;

                //Autocreate payer using the payername

                payer = await _payerService.AddPayerAsync(new Payer { Name = request.PayerName });
                if (!(payer == null)) return payer;

                //TODO: I haven't thought about this case yet. Might throw an exception.
            }

            return payer;
        }

        private async Task<Card?> getRequestCard(MovementRequest request)
        {
            Card? card = null;

            if (request.CardID.HasValue)
            {
                card = await _cardService.GetCardByIdAsync(request.CardID.Value);
                if (!(card == null)) return card;

                throw new NotFoundException($"Card with ID {request.CardID.Value} not found.");
            }

            if (!string.IsNullOrEmpty(request.CardAlias))
            {
                card = await _cardService.GetCardByAliasAsync(request.CardAlias);

                if (!(card == null)) return card;

                //Autocreate card using the cardAlias

                card = await _cardService.AddCardAsync(new Card { Alias = request.CardAlias });
                if (!(card == null)) return card;

                //TODO: I haven't thought about this case yet. Might throw an exception.
            }

            return card;
        }

    }
}
