using BaziDanni_k.p_.Repositories.Common;

namespace BaziDanni_k.p_.Repositories.abonament;

public sealed class AbonamentRepository(string cs) : GenericOracleRepository(cs, "abonament", "N_abonament", "N_abonament", "Period_meseci", "Cena_lv");
