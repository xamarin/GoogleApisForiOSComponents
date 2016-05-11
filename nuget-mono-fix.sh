#!/bin/sh

curdir=$(pwd)

rm -rf nuget-mono-fix
FILES=`unzip -Z1 $1`
unzip $1 -d nuget-mono-fix

cd nuget-mono-fix


for filename in $FILES; do \
	touch $filename; \
	zip --delete $1 $filename; \
	zip --update $1 $filename; \
done

cd $curdir
rm -rf nuget-mono-fix

