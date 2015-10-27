#!/bin/bash

n=0
d=`dirname $0`
if [ "$1" == "-l" ] ; then
    lcl="-l"
fi

echo $$ > run-forever.pid

while true ; do
    nh=`printf nh%04d $n`
    if mkdir $nh ; then
        cd $nh
        ../$d/run.sh $lcl
        cd ..
    fi

    n=$((n+1))
done
