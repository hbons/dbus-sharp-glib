ASSEMBLY = dbus-sharp-glib
TARGET = $(ASSEMBLY).dll

CSFLAGS = \
	-debug -target:library -keyfile:$(top_srcdir)/dbus-sharp.snk

LIBFLAGS = \
	$(DBUS_SHARP_LIBS)

CSFILES = \
	$(srcdir)/GLib.cs \
	$(srcdir)/GLib.IO.cs

all: $(TARGET)

$(TARGET): $(CSFILES) AssemblyInfo.cs
	$(MCS) -out:$@ $(CSFLAGS) $(LIBFLAGS) $^

install-data-local:
	@if test -n '$(TARGET)'; then                       \
          echo "$(GACUTIL) /i $(TARGET) /f /gacdir $(DESTDIR)$(libdir)";    \
          $(GACUTIL) /i $(TARGET) /package $(PACKAGE)-$(API_VERSION) /f /gacdir $(libdir) /root $(DESTDIR)$(libdir) || exit 1; \
        fi

uninstall-local:
	@if test -n '$(TARGET)'; then                       \
          echo "$(GACUTIL) /u $(ASSEMBLY) /gacdir $(DESTDIR)$(libdir)";  \
          $(GACUTIL) /u $(ASSEMBLY) /package $(PACKAGE)-$(API_VERSION) /gacdir $(libdir) /root $(DESTDIR)$(libdir) || exit 1; \
        fi

EXTRA_DIST = \
	$(CSFILES) \
	$(srcdir)/AssemblyInfo.cs.in \
	$(TARGET).config

CLEANFILES = \
	$(TARGET) \
	$(TARGET).mdb

DISTCLEANFILES = \
	AssemblyInfo.cs

MAINTAINERCLEANFILES = \
	Makefile.in
