using System.Net;
using UnityEngine;

public class StateCodeTranslator : MonoBehaviour
{
    public static string Translate(int statusCode)
    {
        switch (statusCode)
        {
            case 200:
                return "200 OK: 요청 성공. 데이터가 정상적으로 반환되었습니다.";
            case 201:
                return "201 Created: 요청이 성공했으며, 새로운 리소스가 생성되었습니다. (예: 회원가입 성공)";
            case 204:
                return "204 No Content: 요청 성공. 하지만 반환할 콘텐츠(데이터)가 없습니다. (예: 삭제 요청 성공)";
            case 400:
                return "400 Bad Request: 클라이언트의 요청 구문이 잘못되었습니다.";
            case 401:
                return "401 Unauthorized: 인증이 필요합니다. (로그인되지 않음)";
            case 403:
                return "403 Forbidden: 접근 권한이 없습니다.";
            case 404:
                return "404 Not Found: 요청한 리소스(URL)를 찾을 수 없습니다.";
            case 409:
                return "409 Conflict: 동일한 값이 존재합니다(중복 아이디)";
            case 500:
                return "500 Internal Server Error: 서버 내부에서 오류가 발생했습니다.";
            default:
                return $"{statusCode}: {GetCategoryDescription(statusCode)}";
        }
        
    }
    
    private static string GetCategoryDescription(int statusCode)
    {
        if (statusCode >= 100 && statusCode < 200)
            return "정보 (Informational)";
        if (statusCode >= 200 && statusCode < 300)
            return "성공 (Success)";
        if (statusCode >= 300 && statusCode < 400)
            return "리다이렉션 (Redirection)";
        if (statusCode >= 400 && statusCode < 500)
            return "클라이언트 오류 (Client Error)";
        if (statusCode >= 500 && statusCode < 600)
            return "서버 오류 (Server Error)";
        
        return "알 수 없는 상태 코드";
    }
}
