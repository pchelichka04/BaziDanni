using BaziDanni_k.p_.Repositories.Common;

namespace BaziDanni_k.p_.Repositories.zapisani_abonamenti;

public sealed class ZapisaniAbonamentiRepository(string cs) : GenericOracleRepository(cs, "zapisani_abonamenti", "N_chlen", "N_chlen", "N_grupa", "N_abonament", "Data_zapis");
