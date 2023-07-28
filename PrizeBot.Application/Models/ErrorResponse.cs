namespace PrizeBot.Application.Models;

public record ErrorResponse(string MessageError, ErrorCode ErrorCode, Exception Exception = null);