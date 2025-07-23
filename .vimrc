set nocompatible
  
"font
    "set guifont=FixedSys:h10
    set guifont=consolas:h12
    "set guifont=Monospace\ 12
    "set guifont=Fira_Code:h11:cANSI:qDRAFT
    "set  guifont=Fira\ Code\ Regular\ 12
    " for linux
    "set guifont=Source\ Code\ Pro\ 11
    "for windows
    "set guifont=Source_Code_Pro:h12:cANSI:qDRAFT

" leader key 

    let mapleader=','

"encoding
    set fencs=utf-8
    set enc=utf-8
"    set bomb

"update
    set updatetime=300

"grep
    "set grepprg=grep\ -nrH
    set grepprg=ag\ --vimgrep\ $*
    set grepformat=%f:%l:%c:%m

"edit
    "set shell=powershell
    set autoindent
    set tabstop=4
    set expandtab
    "set noexpandtab
    set shiftwidth=4
    set softtabstop=0
    set mousehide
    set ve=all
    set nowrapscan
    set nowrap
    set clipboard=unnamed
    set nu
    set hls
	set noic
	"set ic
	set noic
    set autoread
    "set relativenumber
    set backspace=indent,eol,start
    set notimeout
    set noequalalways
    set statusline=%t%m 
    "set nosplitbelow
    set splitbelow

    "tab display
    set guitablabel=\[%N\]\ %t\ %M     

    "set nobackup       "no backup files
    "set nowritebackup  "only in case you don't want a backup file while editing
    "set noswapfile     "no swap files

    "au GUIEnter * simalt ~x  "maximize window

"vim-plug

    " how to install ": PlugInstall"

    call plug#begin()
    " The default plugin directory will be as follows:
    "   - Vim (Linux/macOS): '~/.vim/plugged'
    "   - Vim (Windows): '~/vimfiles/plugged'
    "   - Neovim (Linux/macOS/Windows): stdpath('data') . '/plugged'
    " You can specify a custom plugin directory by passing it as the argument
    "   - e.g. `call plug#begin('~/.vim/plugged')`
    "   - Avoid using standard Vim directory names like 'plugin'

    " Make sure you use single quotes

    Plug 'majutsushi/tagbar'
    Plug 'karoliskoncevicius/vim-sendtowindow'
    Plug 'preservim/nerdtree'
    Plug 'jlanzarotta/bufexplorer'
    Plug 'thinca/vim-fontzoom'
    Plug 'vim-airline/vim-airline'
    Plug 'vim-airline/vim-airline-themes'
	Plug 'ctrlpvim/ctrlp.vim'

    call plug#end()

"tags

    set tags=./tags,tags

"completion popup
    set completeopt=longest,menuone
"file
    " Change directory to the current buffer when opening files.
    "set autochdir
"language support
    syntax on
"filetype 
    filetype plugin indent on
    filetype on 
	syntax enable
"ui
    "colorscheme torte
    colorscheme koehler
    "colorscheme cyberpunk
    "colorscheme neuromancer
    "colorscheme darkblue
    "colorscheme vividchalk

    "set guioptions-=m  "remove menu bar
    set guioptions-=T  "remove toolbar
    set guioptions-=r  "remove right-hand scroll bar
    set guioptions-=L  "remove left-hand scroll bar
    
function! TabMove(direction)
    " get number of tab pages.
    let ntp=tabpagenr("$")
    " move tab, if necessary.
    if ntp > 1
        " get number of current tab page.
        let ctpn=tabpagenr()
        " move left.
        if a:direction < 0
            let index=((ctpn-1+ntp-1)%ntp)
        else
            let index=(ctpn%ntp)
        endif
        " move tab page.
        execute "tabmove ".index
    endif
endfunction

function! WorkSetting_1()
    execute("cd c:/GameDevelopment")

    call feedkeys(":below term\<cr>")
    call feedkeys("SetEnv.bat\<cr>")

    call feedkeys("\<c-w>k")
    call feedkeys(":resize 70\<cr>")
    call feedkeys(":args 01.Src/01.ScriptsCommon/**/*.cs\<cr>")
    call feedkeys(":args 01.Src/02.Scripts/**/*.cs\<cr>")

    call feedkeys(":b UnitTest\<cr>")
    call feedkeys("\<F9>")
endfunction

function! OpenWork()
    call feedkeys(":cd C:/UnityProjects/20250319_ShyDevil/Assets/003.Scripts\<cr>")
    call feedkeys(":args **/*.cs\<cr>")
endfunction

function! OpenTODO()
    call feedkeys(":e c:/myhome/todo.txt\<cr>")
endfunction

function! OpenUnityCodeSnippet()
    call feedkeys(":e c:/myhome/Unity/UnityCodeSnippet.cs\<cr>")
endfunction

function! OpenGodotCodeSnippet()
    call feedkeys(":e c:/myhome/Godot/GodotCodeSnippet.gd\<cr>")
endfunction

function! OpenWinformCodeSnippet()
    call feedkeys(":e c:/myhome/Winform/WinformCodeSnippet.cs\<cr>")
endfunction


function! ShowTagbar()
    call feedkeys(":TagbarToggle\<cr>")
endfunction

function! VimGrep()
    call feedkeys(":vimgrep   ./Src/**/*.cs")
    call feedkeys("\<Left>")
    call feedkeys("\<Left>")
    call feedkeys("\<Left>")
    call feedkeys("\<Left>")
    call feedkeys("\<Left>")
    call feedkeys("\<Left>")
    call feedkeys("\<Left>")
    call feedkeys("\<Left>")
    call feedkeys("\<Left>")
    call feedkeys("\<Left>")
    call feedkeys("\<Left>")
    call feedkeys("\<Left>")
    call feedkeys("\<Left>")
    call feedkeys("\<Left>")
    call feedkeys("\<Left>")
endfunction

let g:saved_winid = -1

function! SaveWindow()
    "echom 'SaveWindow()'
    let g:saved_winid = win_getid()
endfunction

function! RestoreWindow()
    "echom 'RestoreWindow() step-1'
    if g:saved_winid != -1 
        call win_gotoid(g:saved_winid)
        "echom 'RestoreWindow() step-2'
    endif
endfunction

function! GoToTerminalWindow()
  for win in range(1, winnr('$'))
    if getbufvar(winbufnr(win), '&buftype') ==# 'terminal'
      execute win . 'wincmd w'
      return 1
    endif
  endfor
  return 0
endfunction

function! Build()
	let l:current_filetype = &filetype
	execute ("w")
	if l:current_filetype == "gdscript" || l:current_filetype == "cs" 
        if GoToTerminalWindow()
            call feedkeys("build.bat\<CR>", 'n')
			call feedkeys("\<c-w>p")
		endif
	endif
endfunction

function! BuildAndRun()
	let l:current_filetype = &filetype
	execute ("w")
	if l:current_filetype == "gdscript" || l:current_filetype == "cs" 
        if GoToTerminalWindow()
            call feedkeys("build_and_run.bat\<CR>", 'n')
			call feedkeys("\<c-w>p")
		endif
	endif
endfunction

function! ReloadSources()
    execute("args 01.Src/01.ScriptsCommon/**/*.cs\<cr>")
    execute("args 01.Src/02.Scripts/**/*.cs\<cr>")

endfunction

function! IncreaseWinHeight()
	let l:curr_height = winheight(0)
    execute("resize " . (curr_height + 1))
endfunction

function! DecreateWinHeight()
	let l:curr_height = winheight(0)
    execute("resize " . (curr_height - 1))
endfunction


set guioptions+=a

"fold

    set foldmethod=marker
    "set foldopen-=hor  " l, h key 로 open하는 거 막기

    "highlight Folded guibg=black guifg=orange
    "highlight Folded guibg=white guifg=blue
    "highlight Folded guibg=white guifg=black
    "highlight FoldColumn guibg=darkgrey guifg=white
    "highlight Folded guibg=blue guifg=orange
    highlight Folded guibg=blue guifg=white
    "highlight Folded guibg=darkgrey guifg=white

"taglist
    let g:Tlist_Show_One_File=1


set backupdir=~/vimbackup
set directory=~/vimswap
set undodir=~/vimundo

"tab name file name only  not full path
"set guitablabel=\[%N\]\ %t\ %M 

"no visual bell
set noerrorbells visualbell t_vb=
autocmd GUIEnter * set visualbell t_vb=
" Disable automatic comment insertion
autocmd FileType * setlocal formatoptions-=c formatoptions-=r formatoptions-=o

"folding 

        "function! MyFoldText()
        "    let nblines = v:foldend - v:foldstart + 1
        "    let w = winwidth(0) - &foldcolumn - (&number ? 8 : 0)
        "    let line = getline(v:foldstart + 1)
        "    let comment = substitute(line, '#\|/\*\|\*/\|{{{\d\=', '', 'g')             "}}}
        "    let txt = line
        "    return txt
        "endfunction

		function! FoldText()
              let l:line = getline(v:foldstart)
              let l:clean = substitute(l:line, '//.*$', '', '')        " C/C++ 스타일 주석 제거
              let l:clean = substitute(l:clean, '#.*$', '', '')        " Python 스타일 주석 제거
              let l:clean = substitute(l:clean, '--.*$', '', '')       " Lua/SQL 스타일 주석 제거
              return l:clean
		endfunction

        "set fillchars=fold:\ 
        set foldtext=FoldText()

" Nerdtree

    let NERDTreeIgnore = ['\.meta$']
    nnoremap <silent><nowait> <Leader>n :NERDTree<CR>

"tagbar

    nnoremap <silent><nowait> <C-F9> :call ShowTagbar()<CR>
    let g:tagbar_left = 0   " right
    "let g:tagbar_left = 1    " left

"FzF
    "끝에 <cr> 다음에 space 붙어 있음
    "nnoremap <silent><nowait> <Leader>b :Buffers<cr>
    "nnoremap <Leader>f :FZF --query=.cs$ C:/MyProjects/MyPrototype/Assets<cr> 
    nnoremap <Leader>f :FZF --query=.cs$ <cr> 

"bufexplorer

    let g:bufExplorerDefaultHelp=0                  " Do not show default help.
    let g:bufExplorerDisableDefaultKeyMapping=1     "To control whether the default key mappings are enabled or not
    let g:bufExplorerDetailedHelp=0                 " Do not show detailed help.
    let g:bufExplorerShowDirectories=0              " Do not show directories.
    let g:bufExplorerShowNoName=0                   " Do not "No Name" buffers.
    let g:bufExplorerShowRelativePath=1             " Show relative paths.
    let g:bufExplorerShowTabBuffer=0                " To control whether or not to show buffers on for the specific tab or not  
    let g:bufExplorerShowUnlisted=0                 " Show unlisted buffers.
    let g:bufExplorerSortBy='name'                  " Sort by the buffer's name.

    nnoremap <silent> <Leader>b :BufExplorer<CR>

"airline
    let g:airline#extensions#tabline#enabled = 1
    let g:airline#extensions#tabline#tab_nr_type = 0
    let g:airline#extensions#tabline#formatter = 'unique_tail'
    "let g:airline_theme='luna'  " 또는 solarized, gruvbox 등 원하는 테마로

" godot
set tags=.\tags;tags

	let g:tagbar_type_gdscript = {
				\'ctagstype' :'gdscript',
				\'kinds':[
				\'l:classes',
				\'c:constants',
				\'v:variables',
				\'e:exports',
				\'o:onready',
				\'p:preloads',
				\'s:signals',
				\'f:functions',
				\'m:static functions',
				\]
				\}

	let g:tagbar_type_snippets = {
				\'ctagstype' :'snippets',
				\'kinds':[
				\'s:snippet',
				\]
				\}

"ctrl-p
	" document
	" https://ctrlpvim.github.io/ctrlp.vim/#installation
	let g:ctrlp_map = '<c-p>'


au BufRead,BufNewFile *.gd set filetype=gdscript

" key mapping

        " key mapping
                inoremap    <cr>        <esc>
                nnoremap    <cr>        :nohls<cr>

                nnoremap    <c-y>       :redraw<cr>

                " search visual mode selection 
                vnoremap    <c-e>       y/\V<C-R>=escape(@",'/\')<cr><cr>N

                " 해당태그를 우측창으로 스플릿해서 열어준다.
                "nnoremap <C-]> :execute "vertical rightb ptag " . expand("<cword>")<CR>
                "nnoremap <C-]> :tabnew %<CR>g<C-]>

                " transpose words
                "vmap              <Leader>tw         :TransposeWords<CR>

                " delete blank line
                "vmap              <Leader>dl         :g/^\s*$/d<CR>:nohls<CR>
                " delete multiple space (multiple space -> one space)
                "vmap              <Leader>dms        :s/ \+/ /g<CR>:nohls<CR>

                " Camelcase From Upper Under score 
                "   UNDER_SCORES -> underScores
                "vmap              <Leader>cfuu       :s#_*\(\u\)\(\u*\)#\1\L\2#g<CR>:nohls<CR>
                " Camelcase From Lower Under score 
                "   under_scores -> underScores
                "vmap              <Leader>cflu       :s#_\(\l\)#\u\1#g<CR>:nohls<CR>

                " vim-sendtowindow
                let g:sendtowindow_use_defaults=0

                "nmap              <c-h>              gT
                "nmap              <c-l>              gt
                "tnoremap          <c-h>              <esc><c-w>gT
                "tnoremap          <c-l>              <esc><c-w>gt


                nnoremap <c-1>  :put =map(range(0,999), 'printf(''%03d'', v:val)')


                " In the quickfix window, <CR> is used to jump to the error under the
                " cursor, so undefine the mapping there.
                autocmd BufReadPost quickfix nnoremap <buffer> <CR> <CR>

                " 파일열때마다 자동으로 파일위치의 디렉토리를 현재디렉토리로 변경
                "autocmd BufEnter * silent! cd %:p:h

                map <F1> :call TabMove(-1)<CR>
                map <F2> :call TabMove(1)<CR>


                xmap              <Leader>e          <Plug>SendDownV
                " terminal mode  , 아래거 안먹음 나중에 확인 필요
                tnoremap <Leader><esc> <c-\><c-n>
                "nnoremap <Leader>w :silent !"C:\Godot 4 2D Prototype\run.bat"<cr>
                "nnoremap <c-e> <c-w>jRun.bat<cr><c-w>p

                """""""""""""""""""""""""""""""""""""""""""""""""""""""""""""
                " 저장시 빌드 
                """""""""""""""""""""""""""""""""""""""""""""""""""""""""""""

                "autocmd  BufWritePost *.cs call BuildAndRunUnitTest()
                "nnoremap <c-d> :w<cr>:silent !godot<cr>
                "inoremap <c-d> :w<cr>:silent !godot<cr> 
                "autocmd FileType cs cnoreabbrev w call BuildAndRunUnitTest()
                "autocmd FileType cs cnoreabbrev r call BuildAndRun()

                "cnoreabbrev w call BuildAndRunUnitTest()
                "cnoreabbrev r call BuildAndRun()

                nnoremap    <c-0> :call VimGrep()<cr>

                nnoremap    <c-l> <c-w>100l

                nnoremap    <s-h> gT
                nnoremap    <s-l> gt


                " ev for edit vimrc
                nnoremap <f1> :e $MYVIMRC<cr>
                " sv for source vimrc (reload vimrc)
                nnoremap <f2> :source $MYVIMRC<cr>

                "map <F11> :call OpenGodotCodeExamples()<cr>
                map <F12> :call OpenTODO()<cr>
                map <F11> :call OpenGodotCodeSnippet()<cr>
                map <F10> :call OpenUnityCodeSnippet()<cr>
                map <F9> :call OpenWinformCodeSnippet()<cr>

                cnoreabbrev w call Build()
                cnoreabbrev r call BuildAndRun()

				nnoremap <c-k> :call IncreaseWinHeight()<cr>
				nnoremap <c-j> :call DecreateWinHeight()<cr>


