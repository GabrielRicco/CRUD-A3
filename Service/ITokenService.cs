using Dto;
using Models;

namespace Services;

public interface ITokenService {
    string GenerateToken(Login user)
;}