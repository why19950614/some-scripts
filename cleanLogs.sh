echo "Please wait..."  
        m=`date -d "1 months ago" +%Y-%m`    #获取上个月的yyyy-mm格式的日期字符串
        m2=`date -d "1 months ago" +%Y%m`
        index=0
        f=`find MESServer/ -mtime +14 -name "*.log"`  #获取logs下文件列表( MESServer 是日志的所在的路径)
        for name in $f
        do
                #n=`expr "$name" : '.*\([0-9]\{4\}-[0-9]\{2\}\).*'`    #从文件名称中提取yyyy-mm格式日期
                #if [ "$n" != "" ] && [ "$n" = "$m" ]
                #then
                        f[$index]="$name"    #logs文件夹下符合要求的文件名称放入数组
                #else
                #        f[$index]=""
                #fi
                (( index ++ ))
        done
        echo "$f"
        str=${f[@]}
        if [ "${#str}" -gt 0 ]       #如果大于 0
        then
        zip MESServer/$m2.zip  $str    #压缩数组中的文件为yyyymm.zip文件，打包放在log/MESServer下
        else
        echo "No files found."
        exit 0
        fi
        echo "$m2.zip maked, now delete old files."
        rm -fr $str        #删除已被打包文件
        echo "done."
        exit 0