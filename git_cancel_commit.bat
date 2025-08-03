REM 커밋을 취소(바로 이전커밋으로 변경) 하고 스테이징도 취소한다.
REM github 에 큰파일을 올리려다가 실패할경우 이명령으로 
REM 현재 커밋을 취소하고 파일 삭제후 다시 push하면 된다.
git reset --mixed HEAD~1
