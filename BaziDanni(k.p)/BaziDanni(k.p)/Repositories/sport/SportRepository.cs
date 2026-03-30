using BaziDanni_k.p_.Repositories.Common;

namespace BaziDanni_k.p_.Repositories.sport;

public sealed class SportRepository(string cs) : GenericOracleRepository(cs, "sport", "N_sport", "N_sport", "Ime_sport", "Cvyat");
